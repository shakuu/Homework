namespace Poker.Tests.Logic
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        // A hand is valid when it consists of exactly 5 different cards.
        [Test]
        public void IsValidHand_HandHasLessThanFiveCards_ShouldReturnFalse()
        {
            // Arrange
            var hand = new FakeHand(3);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var result = pokerHandChecker.IsValidHand(hand);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidHand_HandHasMoreThanFiveCards_ShouldReturnFalse()
        {
            // Arrange
            var hand = new FakeHand(6);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var result = pokerHandChecker.IsValidHand(hand);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidHand_HandHasDuplicateCards_ShouldReturnFalse()
        {
            // Arrange
            var hand = new FakeHand(5);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var result = pokerHandChecker.IsValidHand(hand);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidHand_HandHasFiveDifferentCards_ShouldReturnTrue()
        {
            // Arrange
            var cards = new List<ICard>()
            {
                new ConstantStringFakeCard("card1"),
                new ConstantStringFakeCard("card2"),
                new ConstantStringFakeCard("card3"),
                new ConstantStringFakeCard("card4"),
                new ConstantStringFakeCard("card5"),
            };

            var hand = new FakeHand(cards);
            var pokerHandChecker = new PokerHandsChecker();

            // Act
            var result = pokerHandChecker.IsValidHand(hand);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
