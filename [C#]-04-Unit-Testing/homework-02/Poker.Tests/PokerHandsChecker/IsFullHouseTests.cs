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
    }
}
