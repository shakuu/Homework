namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsOnePairTests
    {
        [Test]
        public void IsOnePair_HandHasTwoCardsWithEqualFaceValueAndTwoOfTheRemainingCardsFormAThreeOfAKind_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsFullHouse);
            var pokerHandChecker = new PokerHandsChecker();

            var actualResult = pokerHandChecker.IsOnePair(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsOnePair_HandHasTwoCardsWithEqualFaceValueAndTwoOfTheRemainingCardsFormASecondPair_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsTwoPair);
            var pokerHandChecker = new PokerHandsChecker();

            var actualResult = pokerHandChecker.IsOnePair(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsOnePair_HandHasTwoCardsWithEqualFaceValueAndThreeKickers_ShouldReturnTrue()
        {
            // Arrange 
            var hand = new HandTypePresetsFakeHand(HandType.IsOnePair);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandChecker.IsOnePair(hand);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}
