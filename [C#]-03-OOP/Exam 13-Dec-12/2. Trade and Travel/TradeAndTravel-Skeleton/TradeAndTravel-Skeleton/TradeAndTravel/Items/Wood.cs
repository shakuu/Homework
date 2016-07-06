namespace TradeAndTravel
{
    public class Wood : Item
    {
        const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    if (this.Value > 0)
                    {
                        this.Value--;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
