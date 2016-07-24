namespace Poker.Tests.Models
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Poker;
    using Poker.Tests.Fakes;

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void ToString_ShouldReturnACorrectString()
        {
            var listOfCards = new List<ICard>()
            {
                new ConstantStringFakeCard(),
                new ConstantStringFakeCard()
            };
            var hand = new Hand(listOfCards);

            var expectedToStringResult = string.Join(" ", listOfCards);
            var actualToStringResult = hand.ToString();

            Assert.AreEqual(expectedToStringResult, actualToStringResult);
        }
    }
}
