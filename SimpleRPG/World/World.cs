using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURERS_PASS = 10;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 1;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMIST_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty Sword", "Rusty Swords", 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake Fang", "Snake Fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snake Skin", "Snake Skinds"));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider Fang", "Spider Fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider Silk", "Spider Silks"));
            Items.Add(new Item(ITEM_ID_ADVENTURERS_PASS, "Adventurer Pass", "Adventurer Passes"));
        }
        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemById(ITEM_ID_RAT_TAIL), false, 75));
            rat.LootTable.Add(new LootItem(ItemById(ITEM_ID_PIECE_OF_FUR), true, 75));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemById(ITEM_ID_SPIDER_FANG), true, 75));
            snake.LootTable.Add(new LootItem(ItemById(ITEM_ID_SNAKESKIN), false, 25));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemById(ITEM_ID_SPIDER_FANG), true, 75));
            giantSpider.LootTable.Add(new LootItem(ItemById(ITEM_ID_SPIDER_SILK), false, 25));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }
        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will recieve a healing potion and 10 gold pieces", 20, 10
                    );

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemById(ITEM_ID_RAT_TAIL), 3));
            clearAlchemistGarden.RewardItem = ItemById(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will recieve an adventurers pass and 10 gold pieces", 20, 10
                    );

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemById(ITEM_ID_SNAKE_FANG), 3));
            clearFarmersField.RewardItem = ItemById(ITEM_ID_ADVENTURERS_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }
        private static void PopulateLocations()
        {
            //Create all the locations
            Location home = new Location(LOCATION_ID_HOME, "Home", "You really need to clean up the place...");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town Square", "You see a fountain...");

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's Hut", "There are many strange plants and phials on the shelves...");
            alchemistHut.QuestAvaliableHere = QuestById(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMIST_GARDEN, "Alchemist's Garden", "You stand in a labrinth of plants...");
            alchemistsGarden.MonsterLivingHere = MonsterById(MONSTER_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farm House", "There is a small farm house, with a farmer standing at the porch...");
            farmhouse.QuestAvaliableHere = QuestById(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersfield = new Location(LOCATION_ID_FARM_FIELD, "Farmer's Field", "You see rows of plants growing here...");
            farmersfield.MonsterLivingHere = MonsterById(MONSTER_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard Post", "There is a large, tough-looking guard here...", ItemById(ITEM_ID_ADVENTURERS_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Stone Bridge", "You stand apon a stone bridge crossing a small river...");

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering the foliage around you...");
            spiderField.MonsterLivingHere = MonsterById(MONSTER_ID_GIANT_SPIDER);

            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersfield;

            farmersfield.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;


            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersfield);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemById(int id)
        {
            foreach(Item item in Items)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Quest QuestById(int id)
        {
            foreach(Quest quest in Quests)
            {
                if(quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }

        public static Monster MonsterById(int id)
        {
            foreach(Monster monster in Monsters)
            {
                if(monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Location LocationById(int id)
        {
            foreach(Location location in Locations)
            {
                if(location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
