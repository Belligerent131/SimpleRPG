

namespace SimpleRPG
{
    public class HealingPotion : Item, IItems
    {
        public int AmountToHeal { get; set; }

        public HealingPotion(int id, string name, string namePlural, int amountToHeal)
            : base(id, name, namePlural)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
