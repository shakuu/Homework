namespace ArmyOfCreatures.Tests.Logic
{
    using System;

    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Creatures;

    [TestFixture]
    public class CreaturesFactoryTests
    {
        [Test]
        public void CreateCreature_ShouldThrow_IfPassedAStringWithAnUnexistingType()
        {
            // Arrange
            var creatureTypeName = "unexisting type";
            var creaturesFactory = new CreaturesFactory();

            // Act and Assert
            var resultingException = Assert.Throws<ArgumentException>(() => creaturesFactory.CreateCreature(creatureTypeName));
            Assert.IsTrue(resultingException.Message.Contains("Invalid creature type"));
        }

        [Test]
        public void CreateCreature_ShouldThrow_IfPassedStringIsNullOrEmpty()
        {
            // Arrange
            var creatureTypeName = string.Empty;
            var creaturesFactory = new CreaturesFactory();

            // Act and Assert
            var resultingException = Assert.Throws<ArgumentNullException>(() => creaturesFactory.CreateCreature(creatureTypeName));
            Assert.IsTrue(resultingException.Message.Contains("Creature Name is null or empty"));
        }

        [Test]
        [TestCase("Angel", typeof(Angel))]
        [TestCase("Archangel", typeof(Archangel))]
        [TestCase("ArchDevil", typeof(ArchDevil))]
        [TestCase("Behemoth", typeof(Behemoth))]
        [TestCase("Devil", typeof(Devil))]
        public void CreateCreature_CreatesAnInstanceOfTheCorrectType(string creatureTypeName, Type expectedType)
        {
            // Arrange
            var creaturesFactory = new CreaturesFactory();

            // Act
            var resultingInstance = creaturesFactory.CreateCreature(creatureTypeName);
            var actualInstanceType = resultingInstance.GetType();
            // Assert
            Assert.AreEqual(expectedType, actualInstanceType);
        }
    }
}
