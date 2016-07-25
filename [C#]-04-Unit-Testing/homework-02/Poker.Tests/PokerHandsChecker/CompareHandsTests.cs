namespace Poker.Tests.PokerHandsChecker
{
    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Data;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class CompareHandsTests
    {
        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.ComapreHandsAllHandTypesButStraightFlushEnumerable)]
        public void CompareHandsTests_FirstHandStraightFlushAndAnyOtherSecondHand_ShouldReturnPlusOne(IHand handWhichIsNotAStraightFlush)
        {
            // Arrange
            var firstHand = new HandTypePresetsFakeHand(HandType.IsStraightFlush);
            var secondHand = handWhichIsNotAStraightFlush;
            var handChecker = new PokerHandsChecker();

            // Act
            var expectedResult = 1;
            var actualResult = handChecker.CompareHands(firstHand, secondHand);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.ComapreHandsAllHandTypesButStraightFlushEnumerable)]
        public void CompareHands_FirstHandAnyTypeButStraightFlushSecondHandStraightFlush_ShouldReturnMinusOne(IHand handWhichIsNotAStraightFlush)
        {
            // Arrange
            var firstHand = handWhichIsNotAStraightFlush;
            var secondHand = new HandTypePresetsFakeHand(HandType.IsStraightFlush);
            var handChecker = new PokerHandsChecker();

            // Act
            var expectedResult = -1;
            var actualResult = handChecker.CompareHands(firstHand, secondHand);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
