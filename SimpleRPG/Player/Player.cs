using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public class Player : LivingCreature, IPlayer
    {
        public int Gold { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuests> Quests { get; set; }
        public Location CurrentLocation { get; set; }

        /// <summary>
        /// Default constructor for the Player Base class.
        /// </summary>
        /// <param name="currentHitpoints">Player's current Hitpoints. Passed to <see cref="LivingCreature"/></param>
        /// <param name="maximumHitpoints">Player's maximum Hitpoints. Passed to <see cref="LivingCreature"/></param>
        /// <param name="gold">Amount of gold player currently has</param>
        /// <param name="level">The player's level</param>
        /// <param name="experiencePoints">Amount of experience points the player has.</param>
        public Player (int currentHitpoints, int maximumHitpoints, int gold, int level, int experiencePoints)
            : base(currentHitpoints, maximumHitpoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuests>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if(location.ItemRequiredToEnter == null)
            {
                return true;
            }

            foreach(InventoryItem ii in Inventory)
            {
                if(ii.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach(PlayerQuests pq in Quests)
            {
                if(pq.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach(PlayerQuests pq in Quests)
            {
                if(pq.Details.ID == quest.ID)
                {
                    return pq.IsCompleted;
                }
            }
            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach(QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach(InventoryItem ii in Inventory)
                {
                    if(ii.Details.ID == qci.Details.ID)
                    {
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach(InventoryItem ii in Inventory)
            {
                if(ii.Details.ID == itemToAdd.ID)
                {
                    ii.Quantity++;
                    return;
                }
            }

            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            foreach(PlayerQuests pq in Quests)
            {
                if(pq.Details.ID == quest.ID)
                {
                    pq.IsCompleted = true;

                    return;
                }
            }
        }
    }
}
