namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;
    using System.Collections.Generic;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void Constructor_ShouldInitializeFirstArmyCreaturesCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualFirstArmyCreatures = battleManagerAsPrivateObject.GetField("firstArmyCreatures");

            Assert.IsTrue(actualFirstArmyCreatures is ICollection<ICreaturesInBattle>);
        }

        [Test]
        public void Constructor_ShouldInitializeSecondArmyCreaturesCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualSecondArmyCreatures = battleManagerAsPrivateObject.GetField("secondArmyCreatures");

            Assert.IsTrue(actualSecondArmyCreatures is ICollection<ICreaturesInBattle>);
        }

        [Test]
        public void Constructor_ShouldInitializeCreatureFactoryCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualCreaturesFactory = battleManagerAsPrivateObject.GetField("creaturesFactory");

            Assert.IsTrue(actualCreaturesFactory is ICreaturesFactory);
        }

        [Test]
        public void Constructor_ShouldInitializeLoggerCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualLogger = battleManagerAsPrivateObject.GetField("logger");

            Assert.IsTrue(actualLogger is ILogger);
        }

        [Test]
        public void AddCreature_ShouldThrowWithCorrectMessage_WhenCreatureIdentifierParameterIsNull()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            CreatureIdentifier creatureIdentifier = null;
            var count = 1;

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(creatureIdentifier, count));
            StringAssert.Contains("creatureIdentifier", actualException.Message);
        }

        [Test]
        public void AddCreature_ShouldCallICreaturesFactoryCreateCreatureWithCorrectCreatureNameString_WhenParametersAreValid()
        {
            var expectedCreatureName = "fake";

            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(mock => mock.CreateCreature(expectedCreatureName)).Returns(new FakeCreature());

            var fakeLogger = new Mock<ILogger>();

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(expectedCreatureName + "(1)");
            var count = 1;

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            battleManager.AddCreatures(creatureIdentifier, count);

            fakeFactory.Verify(mock => mock.CreateCreature(expectedCreatureName), Times.Once());
        }
    }
}
