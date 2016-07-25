namespace Poker.Tests.Fakes
{
    using System;
    using System.Collections.Generic;

    using Poker;

    // https://github.com/shakuu/Unit-Testing/tree/master/Topics/02.%20Test-Driven%20Development/homewrok
    public class HandTypePresetsFakeHand : IHand
    {
        public HandTypePresetsFakeHand(HandType type)
        {
            this.Cards = this.initializeCards(type);
        }

        public IList<ICard> Cards { get; private set; }

        private IList<ICard> initializeCards(HandType type)
        {
            var newListOfCards = new List<ICard>();

            switch (type)
            {
                case HandType.IsStraightFlush:
                    newListOfCards = this.GetStraightFlush();
                    break;
                case HandType.IsFourOfAKind:
                    newListOfCards = this.GetFourOfAKind();
                    break;
                case HandType.IsFullHouse:
                    newListOfCards = this.GetFullHouse();
                    break;
                case HandType.IsFlush:
                    newListOfCards = this.GetFlush();
                    break;
                case HandType.IsStraight:
                    newListOfCards = this.GetStraight();
                    break;
                case HandType.IsThreeOfAKind:
                    newListOfCards = this.GetThreeOfAKind();
                    break;
                case HandType.IsTwoPair:
                    newListOfCards = this.GetTwoPair();
                    break;
                case HandType.IsOnePair:
                    newListOfCards = this.GetOnePair();
                    break;
                case HandType.IsHighCard:
                    newListOfCards = this.GetHighCard();
                    break;
                default:
                    throw new ArgumentException("Invalid FakeHand Input");
            }

            return newListOfCards;
        }

        private List<ICard> GetFullHouse()
        {
            var fullHouse = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                new FakeCard(CardFace.Two, CardSuit.Hearts),
                new FakeCard(CardFace.Two, CardSuit.Spades),
                new FakeCard(CardFace.Two, CardSuit.Clubs)
            };

            return fullHouse;
        }

        private List<ICard> GetTwoPair()
        {
            var twoPair = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                new FakeCard(CardFace.Two, CardSuit.Hearts),
                new FakeCard(CardFace.Two, CardSuit.Spades),
                new FakeCard(CardFace.Ten, CardSuit.Clubs)
            };

            return twoPair;
        }

        private List<ICard> GetOnePair()
        {
            var onePair = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                new FakeCard(CardFace.Two, CardSuit.Hearts),
                new FakeCard(CardFace.Seven, CardSuit.Spades),
                new FakeCard(CardFace.Ten, CardSuit.Clubs)
            };

            return onePair;
        }

        private List<ICard> GetStraight()
        {
            var straight = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.King, CardSuit.Diamonds),
                new FakeCard(CardFace.Queen, CardSuit.Hearts),
                new FakeCard(CardFace.Ten, CardSuit.Spades),
                new FakeCard(CardFace.Jack, CardSuit.Clubs)
            };

            return straight;
        }

        private List<ICard> GetThreeOfAKind()
        {
            var threeOfAKind = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                new FakeCard(CardFace.Ace, CardSuit.Hearts),
                new FakeCard(CardFace.Two, CardSuit.Spades),
                new FakeCard(CardFace.Jack, CardSuit.Clubs)
            };

            return threeOfAKind;
        }

        private List<ICard> GetFourOfAKind()
        {
            var fourOfAKind = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                new FakeCard(CardFace.Ace, CardSuit.Hearts),
                new FakeCard(CardFace.Ace, CardSuit.Spades),
                new FakeCard(CardFace.Jack, CardSuit.Clubs)
            };

            return fourOfAKind;
        }

        private List<ICard> GetHighCard()
        {
            var highCard = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Two, CardSuit.Diamonds),
                new FakeCard(CardFace.Four, CardSuit.Hearts),
                new FakeCard(CardFace.Eight, CardSuit.Spades),
                new FakeCard(CardFace.Jack, CardSuit.Clubs)
            };

            return highCard;
        }

        private List<ICard> GetStraightFlush()
        {
            var straightFlush = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.King, CardSuit.Clubs),
                new FakeCard(CardFace.Ten, CardSuit.Clubs),
                new FakeCard(CardFace.Jack, CardSuit.Clubs),
                new FakeCard(CardFace.Queen, CardSuit.Clubs)
            };

            return straightFlush;
        }

        private List<ICard> GetFlush()
        {
            var flush = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Eight, CardSuit.Clubs),
                new FakeCard(CardFace.Jack, CardSuit.Clubs),
                new FakeCard(CardFace.Ten, CardSuit.Clubs),
                new FakeCard(CardFace.Two, CardSuit.Clubs)
            };

            return flush;
        }
    }
}
