namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Data;

    [TestFixture]
    public class IsStraightFlushTests
    {
        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.IsStraightFlushAllFacesCasesAsString)]
        public bool IsStraightFlush_HandHasFiveCardsOfSequentialFaceValueAndOftheSameSuit_ShouldReturnTrue(IHand hand)
        {
            // Arrange
            var pokerHandChecker = new PokerHandsChecker();

            // Act 
            var actualResult = pokerHandChecker.IsStraightFlush(hand);

            // Assert
            return actualResult;
        }
    }
}
