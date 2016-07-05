
namespace TradeAndTravel
{
    using System.Collections.Generic;

    public class Armor : Item
    {
        const int GeneralArmorValue = 5;

        public Armor(string name, Location location = null)
            : base(name, Armor.GeneralArmorValue, ItemType.Armor, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron };
        }
    }
}
