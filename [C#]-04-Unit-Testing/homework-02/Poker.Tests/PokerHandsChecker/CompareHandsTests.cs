namespace Poker.Tests.PokerHandsChecker
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Data;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class CompareHandsTests
    {
        [Test]
        [TestCaseSource(typeof(PokerHandsCheckerTestsData), PokerHandsCheckerTestsData.ComapreHandsAllHandTypesButStraightFlushEnumerable)]
        public void CompareHands_FirstHandStraightFlushAndAnyOtherSecondHand_ShouldReturnPlusOne(IHand handWhichIsNotAStraightFlush)
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

        [Test]
        public void CompareHands_TwoHighCardTypesFirstHandHasHighestCardFaceValue_ShouldReturnPlusOne()
        {
            var firstHandCards = new List<ICard>()
            {
                new FakeCard(CardFace.Four, CardSuit.Clubs),
                new FakeCard(CardFace.Seven, CardSuit.Clubs),
                new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                new FakeCard(CardFace.Nine, CardSuit.Clubs),
                new FakeCard(CardFace.Ten, CardSuit.Spades)
            };
            var secondHandCards = new List<ICard>()
            {
                new FakeCard(CardFace.Four, CardSuit.Clubs),
                new FakeCard(CardFace.Seven, CardSuit.Clubs),
                new FakeCard(CardFace.Queen, CardSuit.Diamonds),
                new FakeCard(CardFace.Nine, CardSuit.Clubs),
                new FakeCard(CardFace.Ten, CardSuit.Spades)
            };
            var firstHand = new FakeHand(firstHandCards);
            var secondHand = new FakeHand(secondHandCards);
            var handChecker = new PokerHandsChecker();

            var expectedResult = 1;
            var actualResult = handChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
