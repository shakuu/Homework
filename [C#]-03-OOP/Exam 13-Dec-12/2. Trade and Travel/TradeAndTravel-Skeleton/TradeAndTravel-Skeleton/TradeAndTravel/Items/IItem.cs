namespace TradeAndTravel
{
    public interface IItem
    {
        ItemType ItemType { get; }
        int Value { get; }

        void UpdateWithInteraction(string interaction);
    }
}