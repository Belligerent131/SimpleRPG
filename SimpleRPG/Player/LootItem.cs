using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public class LootItem
    {
        public Item Details { get; set; }
        public bool IsDefaultItem { get; set; }
        public int DropPercentage { get; set; }

        public LootItem(Item details, bool isDefaultItem, int dropPercentage)
        {
            Details = details;
            IsDefaultItem = isDefaultItem;
            DropPercentage = dropPercentage;
        }
    }
}
