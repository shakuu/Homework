namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Data;

    [TestFixture]
    public class IsStraightTests
    {
        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.IsStraightAllFacesCasesAsString)]
        public bool IsStraight_HandHasFiveCardsOfSequentialFaceValue_ShouldReturnTrue(IHand hand)
        {
            // Arrange
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var actualResult = pokerHandChecker.IsStraight(hand);

            // Assert
            return actualResult;
        }
    }
}
