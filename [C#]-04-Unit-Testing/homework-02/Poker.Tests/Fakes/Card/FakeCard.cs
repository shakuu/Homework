namespace Poker.Tests.Fakes
{
    using Poker;

    public class FakeCard : ICard
    {
        public FakeCard(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }
    }
}
