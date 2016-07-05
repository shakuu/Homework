namespace TradeAndTravel
{
    using System;
    using System.Collections.ObjectModel;

    public abstract class Item : WorldObject, IItem
    {
        public ItemType ItemType { get; private set; }

        public int Value { get; protected set; }

        protected Item(string name, int itemValue, string type, Location location = null)
            : base(name)
        {
            this.Value = itemValue;

            foreach (var itemType in (ItemType[])Enum.GetValues(typeof(ItemType)))
            {
                if (itemType.ToString() == type)
                {
                    this.ItemType = itemType;
                }
            }
        }

        protected Item(string name, int itemValue, ItemType type, Location location = null)
            : base(name)
        {
            this.Value = itemValue;
            this.ItemType = type;
        }

        public Collection<string> InteractionHistory { get; protected set; } = new Collection<string>();

        public virtual void UpdateWithInteraction(string interaction)
        {
            this.InteractionHistory.Add(interaction);
        }

    }
}
