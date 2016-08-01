namespace ArmyOfCreatures.Tests.Extended
{
    using System;

    using NUnit.Framework;

    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;

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

        [Test]
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
    }
}
