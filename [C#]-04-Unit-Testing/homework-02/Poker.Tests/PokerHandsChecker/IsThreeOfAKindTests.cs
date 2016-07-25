namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsThreeOfAKindTests
    {
        [Test]
        public void IsThreeOfAKind_HandHasThreeCardsOfEqualFaceValueAndTwoCardsOfDifferentFaceValue_ShouldReturnTrue()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsThreeOfAKind);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsThreeOfAKind(hand);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void IsThreeOfAKind_HandHasThreeCardsOfEqualFaceValueAndTheOtherTwoFormAPair_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsFullHouse);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsThreeOfAKind_HandHasFourCardsOfTheSameFaceValue_ShouldReturnFalse()
        {
            var hand = new HandTypePresetsFakeHand(HandType.IsFourOfAKind);
            var handChecker = new PokerHandsChecker();

            var actualResult = handChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(actualResult);
        }

    }
}
