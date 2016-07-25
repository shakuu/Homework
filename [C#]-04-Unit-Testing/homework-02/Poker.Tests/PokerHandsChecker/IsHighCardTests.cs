namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsHighCardTests
    {
        [Test]
        public void IsHighCard_HandIsNotAnythingElse_ShouldReturnTrue()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsHighCard);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsOnePair_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsOnePair);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsTwoPair_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsTwoPair);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsThreeOfAKind_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsThreeOfAKind);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsStraight_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsStraight);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsFlush_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsFlush);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsFullHouse_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsFullHouse);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsFourOfAKind_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsFourOfAKind);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsHighCard_HandContainsStriaghtFlush_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsStraightFlush);
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsHighCard(hand);

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}
