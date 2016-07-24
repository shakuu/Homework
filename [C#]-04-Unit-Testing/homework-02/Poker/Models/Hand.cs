namespace Poker
{
    using System.Collections.Generic;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var thisToString = string.Join(" ", this.Cards);
            return thisToString;
        }
    }
}
