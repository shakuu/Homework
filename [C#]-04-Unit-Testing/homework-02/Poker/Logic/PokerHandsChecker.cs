namespace Poker
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            foreach (var card in hand.Cards)
            {
                var numberOfCardWithTheSameString =
                    hand.Cards.Where(c => c.ToString() == card.ToString()).Count();

                if (numberOfCardWithTheSameString > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var groupsOfCardsWithTheSameFaceValue =
                from card in hand.Cards
                group card by card.Face into groups
                orderby groups.Count()
                select groups;

            var result = groupsOfCardsWithTheSameFaceValue
                .Any(group => group.Count() == 4);
            return result;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            var suitToMatch = hand.Cards[0].Suit;

            var hasCardsOfDifferentSuit = hand.Cards.Any(card => card.Suit != suitToMatch);
            if (hasCardsOfDifferentSuit)
            {
                return false;
            }

            var cardValues = hand.Cards
                .Select(card => (int)card.Face)
                .OrderBy(value => value);
            var sequentialRangeFromSmallestCardValue = 
                Enumerable.Range(cardValues.First(), cardValues.Count());

            var enumerateCardValue = cardValues.GetEnumerator();
            var enumerateRange = sequentialRangeFromSmallestCardValue.GetEnumerator();

            while (enumerateCardValue.MoveNext() && enumerateRange.MoveNext())
            {
                var currentCardValue = enumerateCardValue.Current;
                var currentRangeValue = enumerateRange.Current;

                if (currentCardValue != currentRangeValue)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
