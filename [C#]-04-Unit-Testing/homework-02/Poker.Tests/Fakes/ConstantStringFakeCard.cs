namespace Poker.Tests.Fakes
{
    using Poker;

    public class ConstantStringFakeCard : ICard
    {
        private const string FakeString = "card";

        private string toString;

        public ConstantStringFakeCard()
        {

        }

        public ConstantStringFakeCard(string toString)
        {
            this.toString = toString;
        }

        public CardFace Face
        {
            get;
        }

        public CardSuit Suit
        {
            get;
        }

        public override string ToString()
        {
            var thisToString = this.toString == null
                ? ConstantStringFakeCard.FakeString
                : this.toString;

            return thisToString;
        }
    }
}
