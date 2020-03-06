﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestAvaliableHere { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

    public Location(int id, string name, string description, Item itemRequiredToEnter = null, 
        Quest questAvaliableHere = null, Monster monsterLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvaliableHere = questAvaliableHere;
            MonsterLivingHere = monsterLivingHere;

        }
    }
}