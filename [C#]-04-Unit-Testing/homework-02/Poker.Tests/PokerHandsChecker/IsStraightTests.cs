namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsStraightTests
    {
        [Test]
        public void IsStraight_HandHasFiveCardsOfSequentialFaceValue_ShouldReturnTrue()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsStraight);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandChecker.IsStraight(hand);

            // Assert
            Assert.IsTrue(actualResult);
        }
    }
}
