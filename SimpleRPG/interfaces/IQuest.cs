using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public interface IQuest
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int RewardExperiencePoints { get; set; }
        int RewardGold { get; set; }
        List<QuestCompletionItem> QuestCompletionItems { get; set; }
    }
}
