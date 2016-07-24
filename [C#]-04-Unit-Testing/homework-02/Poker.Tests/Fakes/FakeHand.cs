namespace Poker.Tests.Fakes
{
    using System.Collections.Generic;

    using Poker;

    public class FakeHand : IHand
    {
        public FakeHand(int numberOfCards)
        {
            this.Cards = this.GenerateHand(numberOfCards);
        }

        public FakeHand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        private IList<ICard> GenerateHand(int numberOfCards)
        {
            var output = new List<ICard>();
            for (int i = 0; i < numberOfCards; i++)
            {
                var card = new ConstantStringFakeCard();
                output.Add(card);
            }
            return output;
        }
    }
}
