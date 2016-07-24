namespace Poker.Tests.Models
{
    using NUnit.Framework;

    using Poker;

    [TestFixture]
    public class CardTests
    {
        [Test]
        [TestCase(14, 3, ExpectedResult = "A♥")]
        [TestCase(10, 2, ExpectedResult = "10♦")]
        [TestCase(2, 4, ExpectedResult = "2♠")]
        public string ToString_ShouldReturnACorrectString(int cardFace, int cardSuit)
        {
            var testingCard = new Card((CardFace)cardFace, (CardSuit)cardSuit);

            var actualToStringValue = testingCard.ToString();

            return actualToStringValue;
        }
    }
}
