namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

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
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var isStraghtHand = this.CheckIfHandHasFiveSequentialFaceValues(hand);
            var isFlushHand = this.CheckIfHandHasFiveIdenticalSuits(hand);

            var isStraightFlush = isStraghtHand && isFlushHand;
            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var groupsOfCardsWithTheSameFaceValue =
                this.SplitTheHandIntoGroupsOfCardsWithTheSameFaceValue(hand);

            var result = groupsOfCardsWithTheSameFaceValue
                .Any(groupCount => groupCount == 4);
            return result;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var groupsOfCardsWithTheSameFaceValue =
                this.SplitTheHandIntoGroupsOfCardsWithTheSameFaceValue(hand);

            var numberOfGroups = groupsOfCardsWithTheSameFaceValue.Count();
            var hasThreeOfAKind = groupsOfCardsWithTheSameFaceValue.Any(groupCount => groupCount == 3);
            var hasOnePair = groupsOfCardsWithTheSameFaceValue.Any(groupCount => groupCount == 2);

            if (numberOfGroups == 2 && hasThreeOfAKind && hasOnePair)
            {
                return true;
            }
            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var allCardsHaveTheSameSuit = this.CheckIfHandHasFiveIdenticalSuits(hand);
            if (!allCardsHaveTheSameSuit)
            {
                return false;
            }

            var hasStraight = CheckIfHandHasFiveSequentialFaceValues(hand);
            return !hasStraight;
        }

        public bool IsStraight(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var isStraight = this.CheckIfHandHasFiveSequentialFaceValues(hand);
            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var groupsOfCardsWithTheSameFaceValue =
                this.SplitTheHandIntoGroupsOfCardsWithTheSameFaceValue(hand);

            var numberOfGroups = groupsOfCardsWithTheSameFaceValue.Count();
            var hasThreeOfAKind = groupsOfCardsWithTheSameFaceValue.Any(groupCount => groupCount == 3);
            
            if (numberOfGroups == 3 && hasThreeOfAKind)
            {
                return true;
            }
            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var groupsOfCardsWithTheSameFaceValue =
                this.SplitTheHandIntoGroupsOfCardsWithTheSameFaceValue(hand);

            var numberOfGroups = groupsOfCardsWithTheSameFaceValue.Count();
            var numberOfPairs = groupsOfCardsWithTheSameFaceValue
                .Where(groupCount => groupCount == 2)
                .Count();

            if (numberOfGroups == 3 && numberOfPairs == 2)
            {
                return true;
            }
            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var groupsOfCardsWithTheSameFaceValue =
                this.SplitTheHandIntoGroupsOfCardsWithTheSameFaceValue(hand);

            var numberOfGroups = groupsOfCardsWithTheSameFaceValue.Count();
            var containsAPair = groupsOfCardsWithTheSameFaceValue.Any(groupCount => groupCount == 2);

            if (numberOfGroups == 4 && containsAPair)
            {
                return true;
            }
            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            var allPokerHandChckerMethods =
                typeof(PokerHandsChecker)
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance)
                    .Where(method =>
                        method.ReturnType == typeof(bool)
                        && method.Name != "IsHighCard"
                        && method.Name != "IsValidHand"
                        && typeof(object).GetMethods().All(objMethod => objMethod.Name != method.Name));

            foreach (var method in allPokerHandChckerMethods)
            {
                var isPositiveMatch = (bool)method.Invoke(this, new object[] { hand });

                if (isPositiveMatch)
                {
                    return false;
                }
            }
            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<int> SplitTheHandIntoGroupsOfCardsWithTheSameFaceValue(IHand hand)
        {
            var groupsOfCardsWithTheSameFaceValue =
                from card in hand.Cards
                group card by card.Face into groups
                orderby groups.Count() descending
                select groups.Count();

            return groupsOfCardsWithTheSameFaceValue;
        }

        private bool CheckIfHandHasFiveSequentialFaceValues(IHand hand)
        {
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
                    return false;
                }
            }
            return true;
        }

        private bool CheckIfHandHasFiveIdenticalSuits(IHand hand)
        {
            var suitToMatch = hand.Cards[0].Suit;
            var allCardsAreOfTheSameSuit = hand.Cards.All(card => card.Suit == suitToMatch);
            return allCardsAreOfTheSameSuit;
        }
    }
}
