using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public interface IPlayer
    {
        int CurrentHitPoints { get; set; }
        int MaximumHitPoints { get; set; }
        int ExperiencePoints { get; set; }
        int Gold { get; set; }
        int Level{ get; set; }
        List<InventoryItem> Inventory { get; set; }
        List<PlayerQuests> Quests { get; set; }
    }
}
