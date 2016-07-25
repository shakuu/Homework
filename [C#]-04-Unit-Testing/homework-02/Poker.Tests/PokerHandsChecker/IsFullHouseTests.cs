namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsFullHouseTests
    {
        [Test]
        public void IsFullHouse_HandContainsAThreeOfAKindAndOnePairAtTheSameTime_ShouldReturnTrue()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsFullHouse);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsFullHouse(hand);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void IsFullHouse_HandContainsAThreeOfAKindAndTwoCardsOfDifferentFaceValues_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsThreeOfAKind);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsFullHouse(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsFullHouse_HandsContainsOnePairAndThreeCardsOfDifferentFaceValues_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsOnePair);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsFullHouse(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsFullHouse_HandsCointainsTwoPairs_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsTwoPair);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsFullHouse(hand);

            Assert.IsFalse(actualResult);
        }
    }
}
