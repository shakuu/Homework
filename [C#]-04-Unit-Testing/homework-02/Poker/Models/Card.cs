namespace Poker
{
    using System.Collections.Generic;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var suitSymbols = new List<string>()
            {
                "empty",
                "♣",
                "♦",
                "♥",
                "♠"
            };

            var cardFaceToString = (int)this.Face < 10 
                ? ((int)this.Face).ToString() 
                : this.Face.ToString()[0].ToString();

            var thisToString = cardFaceToString + suitSymbols[(int)this.Suit];
            return thisToString;
        }
    }
}
