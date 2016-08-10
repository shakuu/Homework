namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;
    using System.Reflection;
    using System.Runtime.Serialization;

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

        //Call with null valueToParse should throw ArgumentNullException
        [Test]
        public void CreatureIdentifierFromString_ShouldThrowArgumentNullException_WhenStringValueToParseParameterIsNull()
        {
            string valueToParse = null;

            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.ArgumentNullException.With.Message.Contains("valueToParse"));
        }

        //Call with invalid Army number(ex: Angel(test)) test cannot be parsed should throw FormatExcepition
        [Test]
        public void CreatureIdentifierFromString_ShouldThrowFormatExceptions_WhenNumberIsNotValid()
        {
            var valueToParse = "creature(test)";

            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.InstanceOf<FormatException>());
        }

        //Call with invalid string (without brackets to split) should throw IndexOutOfRangeException
        [Test]
        public void CreateIdentifierFromString_ShouldThrowIndexOutOfRangeException_WhenValueToParseDoesNotContainExpectedCharactersToSplitBy()
        {
            var valueToParse = "noParenthesis";

            Assert.That(() => CreatureIdentifier.CreatureIdentifierFromString(valueToParse),
                Throws.InstanceOf<IndexOutOfRangeException>());
        }

        //ToString should output expected result
        [Test]
        public void ToString_ShouldReturn_StringInTheRequiredFormat()
        {
            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var creatureIdentifier = creatureIdentifierConstructor.Invoke(new object[] { "creature", 1 });

            var expectedToString = "creature(1)";
            var actualToString = creatureIdentifier.ToString();

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        [Test]
        public void ToString_ShouldReturn_StringInTheRequiredFormatAgain()
        {
            var creatureIdentifier = (CreatureIdentifier)FormatterServices
                .GetUninitializedObject(typeof(CreatureIdentifier));

            creatureIdentifier.GetType().GetProperty("CreatureType")
                .SetValue(creatureIdentifier, "creature");

            creatureIdentifier.GetType().GetProperty("ArmyNumber")
                .SetValue(creatureIdentifier, 1);

            var expectedToString = "creature(1)";
            var actualToString = creatureIdentifier.ToString();

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }
    }
}
