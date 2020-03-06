using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleRPG
{
    public partial class SimpleRPG : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SimpleRPG()
        {
            InitializeComponent();

            _player = new Player(10, 10, 10, 1, 0);

            MoveTo(World.LocationById(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemById(World.ITEM_ID_RUSTY_SWORD), 1));

            LblHitPoints.Text = _player.CurrentHitPoints.ToString();
            LblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void btnNorth_Click(object sender, System.EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnWest_Click(object sender, System.EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnEast_Click(object sender, System.EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, System.EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnUseWeapon_Click(object sender, System.EventArgs e)
        {
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            _currentMonster.CurrentHitPoints -= damageToMonster;

            rtbMessages.Text += $"You hit the {_currentMonster.Name} for {damageToMonster.ToString()} points. {Environment.NewLine}";

            if(_currentMonster.CurrentHitPoints <= 0)
            {
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += $"You defeated the {_currentMonster.Name}! {Environment.NewLine}";

                _player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
                rtbMessages.Text += $"You recieve {_currentMonster.RewardExperiencePoints.ToString()} experience points! {Environment.NewLine}";

                _player.Gold += _currentMonster.RewardGold;
                rtbMessages.Text += $"You recieve {_currentMonster.RewardGold.ToString()} coins!";

                List<InventoryItem> lootedItems = new List<InventoryItem>();
                foreach(LootItem li in _currentMonster.LootTable)
                {
                    if(RandomNumberGenerator.NumberBetween(1, 100) <= li.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(li.Details, 1));
                    }
                }

                if(lootedItems.Count == 0)
                {
                    foreach(LootItem li in _currentMonster.LootTable)
                    {
                        if(li.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(li.Details, 1));
                        }
                    }
                }

                foreach(InventoryItem ii in lootedItems)
                {
                    _player.AddItemToInventory(ii.Details);

                    if(ii.Quantity == 1)
                    {
                        rtbMessages.Text += $"You loot {ii.Quantity.ToString()} {ii.Details.Name} {Environment.NewLine}";
                    }
                    else
                    {
                        rtbMessages.Text += $"You loot {ii.Quantity.ToString()} {ii.Details.NamePlural} {Environment.NewLine}";
                    }
                }

                LblHitPoints.Text = _player.CurrentHitPoints.ToString();
                LblGold.Text = _player.Gold.ToString();
                lblExperience.Text = _player.ExperiencePoints.ToString();
                lblLevel.Text = _player.Level.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                rtbMessages.Text += Environment.NewLine;
                MoveTo(_player.CurrentLocation);
            }
            else
            {
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);
                rtbMessages.Text += $"The {_currentMonster.Name} did {damageToPlayer.ToString()} points of damage to you! {Environment.NewLine}";

                _player.CurrentHitPoints -= damageToPlayer;

                LblHitPoints.Text = _player.CurrentHitPoints.ToString();

                if(_player.CurrentHitPoints <= 0)
                {
                    rtbMessages.Text += $"The {_currentMonster.Name} killed you! {Environment.NewLine}";

                    MoveTo(World.LocationById(World.LOCATION_ID_HOME));
                }
            }
        }

        private void btnPotion_Click(object sender, System.EventArgs e)
        {
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;

            _player.CurrentHitPoints = (_player.CurrentHitPoints + potion.AmountToHeal);

            if(_player.CurrentHitPoints > _player.MaximumHitPoints)
            {
                _player.CurrentHitPoints = _player.MaximumHitPoints;
            }

            foreach(InventoryItem ii in _player.Inventory)
            {
                if(ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            rtbMessages.Text += $"You drink a {potion.Name} {Environment.NewLine}";

            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

            rtbMessages.Text += $"The {_currentMonster.Name} did {damageToPlayer} points of damage to you! {Environment.NewLine}";

            _player.CurrentHitPoints -= damageToPlayer;
            if(_player.CurrentHitPoints <= 0)
            {
                rtbMessages.Text += $"The {_currentMonster.Name} killed you! {Environment.NewLine}";
                MoveTo(World.LocationById(World.LOCATION_ID_HOME));
            }

            LblHitPoints.Text = _player.CurrentHitPoints.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }

        private void MoveTo(Location newLocation)
        {
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += $"You must have a {newLocation.ItemRequiredToEnter} to enter this location. {Environment.NewLine}";
            }

            _player.CurrentLocation = newLocation;

            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            _player.CurrentHitPoints = _player.MaximumHitPoints;

            LblHitPoints.Text = _player.CurrentHitPoints.ToString();

            if (newLocation.QuestAvaliableHere != null)
            {
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvaliableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvaliableHere);

                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvaliableHere);

                        if (playerHasAllItemsToCompleteQuest)
                        {
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += $"You completed the {newLocation.QuestAvaliableHere.Name} quest. {Environment.NewLine}";

                            _player.RemoveQuestCompletionItems(newLocation.QuestAvaliableHere);

                            rtbMessages.Text += $"You recieve: {Environment.NewLine}";
                            rtbMessages.Text += $"{newLocation.QuestAvaliableHere.RewardExperiencePoints.ToString()} experience points {Environment.NewLine}";
                            rtbMessages.Text += $"{newLocation.QuestAvaliableHere.RewardGold.ToString()} gold {Environment.NewLine}";
                            rtbMessages.Text += newLocation.QuestAvaliableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            _player.ExperiencePoints += newLocation.QuestAvaliableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvaliableHere.RewardGold;

                            _player.AddItemToInventory(newLocation.QuestAvaliableHere.RewardItem);

                            _player.MarkQuestCompleted(newLocation.QuestAvaliableHere);

                        }
                    }
                }
                else
                {
                    rtbMessages.Text += $"You recieve the {newLocation.QuestAvaliableHere.Name} quest. {Environment.NewLine}";
                    rtbMessages.Text += newLocation.QuestAvaliableHere.Description + Environment.NewLine;
                    rtbMessages.Text += $"To complete it, return with: {Environment.NewLine}";
                    foreach (QuestCompletionItem qci in newLocation.QuestAvaliableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += $"{qci.Quantity.ToString()} {qci.Details.Name} {Environment.NewLine}";
                        }
                        else
                        {
                            rtbMessages.Text += $"{qci.Quantity.ToString()} {qci.Details.NamePlural} {Environment.NewLine}";
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    _player.Quests.Add(new PlayerQuests(newLocation.QuestAvaliableHere, false));
                }
            }

            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += $"You see a {newLocation.MonsterLivingHere.Name} {Environment.NewLine}";

                Monster standardMonster = World.MonsterById(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (LootItem lootitem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootitem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnPotion.Visible = true;
                btnUseWeapon.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnPotion.Visible = false;
                btnUseWeapon.Visible = false;
            }

            UpdateInventoryListInUI();
            UpdateQuestListUI();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgInventory.RowHeadersVisible = false;
            dgInventory.ColumnCount = 2;
            dgInventory.Columns[0].Name = "Name";
            dgInventory.Columns[0].Width = 197;
            dgInventory.Columns[1].Name = "Quantity";

            dgInventory.Rows.Clear();

            foreach(InventoryItem ii in _player.Inventory)
            {
                if(ii.Quantity > 0)
                {
                    dgInventory.Rows.Add(new[] { ii.Details.Name, ii.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListUI()
        {
            dgQuests.RowHeadersVisible = false;
            dgQuests.ColumnCount = 2;
            dgQuests.Columns[0].Name = "Name";
            dgQuests.Columns[0].Width = 197;
            dgQuests.Columns[1].Name = "Done?";

            dgQuests.Rows.Clear();

            foreach(PlayerQuests pq in _player.Quests)
            {
                dgQuests.Rows.Add(new[] { pq.Details.Name, pq.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach(InventoryItem ii in _player.Inventory)
            {
                if(ii.Details is Weapon)
                {
                    if(ii.Quantity > 0)
                    {
                        weapons.Add((Weapon)ii.Details);
                    }
                }
            }

            if(weapons.Count == 0)
            {
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach(InventoryItem ii in _player.Inventory)
            {
                if(ii.Details is HealingPotion)
                {
                    if(ii.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)ii.Details);
                    }
                }
            }

            if(healingPotions.Count == 0)
            {
                cboPotions.Visible = false;
                btnPotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }
    }
}