namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Data;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class IsFourOfAKindTests
    {
        [Test]
        public void IsFourOfAKind_HandHasThreeCardsOfTheSameFaceValue_ShouldReturnFalse()
        {
            // Arrange
            var hand = new HandTypePresetsFakeHand(HandType.IsThreeOfAKind);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandChecker.IsFourOfAKind(hand);

            //Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.IsFourOfAKindAllFacesEnumerable)]
        public bool IsFourOfAKind_HandHasFourCardsOfTheSameFaceValue_ShouldReturnTrue(IHand hand)
        {
            // Arrange
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandChecker.IsFourOfAKind(hand);

            //Assert
            return actualResult;
        }
    }
}
