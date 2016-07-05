using System;

namespace TradeAndTravel
{
    public class Forest : Location, IGatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }

        public ItemType GatheredType
        {
            get
            {
                return ItemType.Wood;
            }
        }

        public ItemType RequiredItem
        {
            get
            {
                return ItemType.Weapon;
            }
        }

        public Item ProduceItem(string name)
        {
            return new Wood(name);
        }
    }
}
