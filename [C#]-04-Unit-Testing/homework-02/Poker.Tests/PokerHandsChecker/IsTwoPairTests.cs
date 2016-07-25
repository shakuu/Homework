namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsTwoPairTests
    {
        [Test]
        public void IsTwoPair_HandHasTwoCardsOfTheSameFaceValueAndTheOtherThreeCardsHaveDifferentFaceValues_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsOnePair);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsTwoPair(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsTwoPair_HandHasTwoCardsOfTheSameFaceValueAndTheOtherThreeCardsHaveEqualFaceValue_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsFullHouse);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsTwoPair(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsTwoPair_HandHasTwoSetsOfCardsWithEqualFaceValue_ShouldReturnTrue()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsTwoPair);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandChecker.IsTwoPair(hand);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}
