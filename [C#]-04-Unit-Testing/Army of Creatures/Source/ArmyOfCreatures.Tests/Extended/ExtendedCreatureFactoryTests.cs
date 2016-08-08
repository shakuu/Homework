namespace ArmyOfCreatures.Tests.Extended
{
    using System;

    using NUnit.Framework;

    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class ExtendedCreatureFactoryTests
    {
        [Test]
        public void CreateCreature_ShouldThrow_IfPassedStringIsNullOrEmpty()
        {
            // Arrange
            var creatureTypeName = string.Empty;
            var creaturesFactory = new ExtendedCreaturesFactory();

            // Act and Assert
            var resultingException = Assert.Throws<ArgumentNullException>(() => creaturesFactory.CreateCreature(creatureTypeName));
            Assert.IsTrue(resultingException.Message.Contains("Creature Name is null or empty"));
        }

        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Goblin", typeof(Goblin))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]

        public void CreateCreature_CreatesAnInstanceOfTheCorrectType(string creatureTypeName, Type expectedType)
        {
            // Arrange
            var creaturesFactory = new ExtendedCreaturesFactory();

            // Act
            var resultingInstance = creaturesFactory.CreateCreature(creatureTypeName);
            var actualInstanceType = resultingInstance.GetType();
            // Assert
            Assert.AreEqual(expectedType, actualInstanceType);
        }

        //CreateCreature should throw ArgumentException with message 
        //that contains the string "Invalid creature type",
        //when a string representing non-existing creature type 
        //is passed as a method argument.
        [Test]
        public void CreateCreature_ShouldThrowArgumentExceptionWithCorrectMessage_WhenInputParameterIsStringWithNonexistentCreatureType()
        {
            var factory = new ExtendedCreaturesFactory();
            var invalidCreatureTypeName = "!@##$3$#$asdasd12312312";

            Assert.That(() => factory.CreateCreature(invalidCreatureTypeName),
                Throws.ArgumentException.With.Message.Contains("Invalid creature type"));
        }

        //CreateCreature should return the corresponding creature type based
        //on the string that is passed as a method argument.
        //Test with(AncientBehemoth, CyclopsKing, Goblin, Griffin, WolfRaider
        //and something else for the default case).
        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Goblin", typeof(Goblin))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]
        [TestCase("ArchDevil", typeof(ArchDevil))]
        public void CreateCreaure_ShouldInstantiateTheCorrectTypeCorrespondingToNameParameter_WhenNameParameterIsValid(string name, Type expectedType)
        {
            var factory = new ExtendedCreaturesFactory();

            var actualCreature = factory.CreateCreature(name);

            Assert.That(actualCreature.GetType(), Is.EqualTo(expectedType));
        }
    }
}
