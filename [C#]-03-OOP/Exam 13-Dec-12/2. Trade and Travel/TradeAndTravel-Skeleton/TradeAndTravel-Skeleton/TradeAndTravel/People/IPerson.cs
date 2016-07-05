
namespace TradeAndTravel
{
    using System.Collections.Generic;

    public interface IPerson
    {
        Location Location { get; }

        void AddToInventory(Item item);
        List<Item> ListInventory();
        void RemoveFromInventory(Item item);
    }
}