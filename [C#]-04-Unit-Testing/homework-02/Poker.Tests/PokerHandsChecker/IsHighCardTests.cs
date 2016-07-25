namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsHighCardTests
    {
        // TODO:

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
    }
}
