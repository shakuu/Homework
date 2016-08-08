namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    using NUnit.Framework;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_ShouldThrowArgumentNullException_WhenValueToParseParameterIsNull()
        {
            string valueToParse = null;

            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.ArgumentNullException.With.Message.Contains("valueToParse"));
        }

        [TestCase("")]
        [TestCase("creatureName")]
        public void CreatureIdentifierFromString_ShouldThrowIndexOutOfRangeException_WhenValueToParseParameterDoesNotContainASplitCharacter(string valueToParse)
        {
            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [TestCase("creatureName(armyNumber)")]
        [TestCase("creatureName(15.50)")]
        public void CreatureIdentifierFromString_ShouldThrowFormatException_WhenValueBetweenParenthesesIsNotTheStringRepresenationOfAIntNumber(string valueToParse)
        {
            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.InstanceOf<FormatException>());
        }

        [TestCase("creatureName(1234567891012131415)")]
        [TestCase("creatureName(-1234567891012131415)")]
        public void CreatureIdentifierFromString_ShouldThrowOverflowException_WhenNumberBetweenParenthesisOverflowsIntSize(string valueToParse)
        {
            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.InstanceOf<OverflowException>());
        }

        [Test]
        public void CreateIdentifierFromString_ShouldReturnANewCreatureIdentifierWithCorrectValues_WhenInputParameterIsValid()
        {
            var valueToParse = "creature(5)";

            var actualIdentifier = CreatureIdentifier.CreatureIdentifierFromString(valueToParse);

            Assert.That(actualIdentifier,
                Is.InstanceOf<CreatureIdentifier>()
                    .With.Property("CreatureType").EqualTo("creature")
                    .And.Property("ArmyNumber").EqualTo(5));
        }
    }
}
