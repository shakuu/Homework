namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System.Reflection;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RequirementsBattleManagerTests
    {
        //Add creatures should throw ArgumentNullException, when Identifier is null
        [Test]
        public void AddCreatures_ShouldThrowArgumentNullException_WhenCreatureIdentifierParameterIsNull()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();

            CreatureIdentifier creatureIdentifier = null;
            var count = 10;

            var manager = new BattleManager(mockFactory.Object, mockLogger.Object);

            Assert.That(() => manager.AddCreatures(creatureIdentifier, count),
                Throws.ArgumentNullException.With.Message.Contains("creatureIdentifier"));
        }

        //Add creatures should call CreteCreature from factory
        [Test]
        public void AddCreatures_ShouldCallICreaturesFactoryCreateCreature_WhenInputParametersAreValid()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            mockFactory.Setup(mock => mock.CreateCreature(It.IsAny<string>())).Returns(new FakeCreature());
            var mockLogger = new Mock<ILogger>();

            var creatureIDCtor = typeof(CreatureIdentifier).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var creatureId = (CreatureIdentifier)creatureIDCtor.Invoke(new object[] { "creature", 1 });
            var count = 10;

            var manager = new BattleManager(mockFactory.Object, mockLogger.Object);
            manager.AddCreatures(creatureId, count);

            mockFactory.Verify(mock => mock.CreateCreature(It.Is<string>(str => str == "creature")), Times.Once());
        }

        //Add creatures should call WriteLine from Logger
        [Test]
        public void AddCreatures_ShouldCallILoggerWriteLine_WhenCreatureIsSuccessfullyAdded()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            mockFactory.Setup(mock => mock.CreateCreature(It.IsAny<string>())).Returns(new FakeCreature());
            var mockLogger = new Mock<ILogger>();

            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var creatureIdenifier = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "creature", 1 });
            var count = 10;

            var manager = new BattleManager(mockFactory.Object, mockLogger.Object);
            manager.AddCreatures(creatureIdenifier, count);

            mockLogger.Verify(mock => mock.WriteLine(It.Is<string>(str => str.Contains("Creature added to army"))), Times.Once);
        }
        //Adding creature to Army 3 (not existing) should throw ArgumentException

        //Attacking with null identifier should throw ArgumentNullException

        //Attacking with null unit should throw ArgumentException

        //Attacking successful should call WriteLine from Logger exactly 4 times

        //Attacking with two Behemoths should return right result
        //(two Behemoths attack 1 Behemoth and the expected result is 56) -
        //could be tried with all the other creatures
    }
}
