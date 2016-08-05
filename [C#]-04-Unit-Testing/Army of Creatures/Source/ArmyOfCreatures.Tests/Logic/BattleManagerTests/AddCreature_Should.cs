namespace ArmyOfCreatures.Tests.Logic.BattleManagerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    class BattleManagerAddCreature_Should
    {
        [Test]
        public void ThrowWithCorrectMessage_WhenCreatureIdentifierParameterIsNull()
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
        public void CallICreaturesFactoryCreateCreatureWithCorrectCreatureNameString_WhenParametersAreValid()
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

        [Test]
        public void AddACreatureToFirstArmyCreatures_WhenCreatureIdentifierArmyNumberIsOne()
        {
            var expectedNumberOfCreatures = 1;

            var creatureName = "fake";
            var addToArmyNumber = "1";

            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(moch => moch.CreateCreature(It.IsAny<string>())).Returns(new FakeCreature());

            var fakeLogger = new Mock<ILogger>();

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(string.Format("{0}({1})", creatureName, addToArmyNumber));
            var count = 1;

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var firstArmy = (ICollection<ICreaturesInBattle>)battleManagerAsPrivateObject.GetField("firstArmyCreatures");

            battleManager.AddCreatures(creatureIdentifier, count);

            Assert.AreEqual(expectedNumberOfCreatures, firstArmy.Count);
        }

        [Test]
        public void AddACreatureToSecondArmyCreatures_WhenCreatureIdentifierArmyNumberIsTwo()
        {
            var expectedNumberOfCreatures = 1;

            var creatureName = "fake";
            var addToArmyNumber = "2";

            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(moch => moch.CreateCreature(It.IsAny<string>())).Returns(new FakeCreature());

            var fakeLogger = new Mock<ILogger>();

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(string.Format("{0}({1})", creatureName, addToArmyNumber));
            var count = 1;

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var secondArmy = (ICollection<ICreaturesInBattle>)battleManagerAsPrivateObject.GetField("secondArmyCreatures");

            battleManager.AddCreatures(creatureIdentifier, count);

            Assert.AreEqual(expectedNumberOfCreatures, secondArmy.Count);
        }

        [Test]
        public void AddTheCorrectCreatureType()
        {
            var fakeCreature = new FakeCreature();

            var stubFactory = new Mock<ICreaturesFactory>();
            stubFactory.Setup(factory => factory.CreateCreature(It.IsAny<string>())).Returns(fakeCreature);

            var fakeLogger = new Mock<ILogger>();

            var creatureName = "fake";
            var addToArmyNumber = "1";
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(string.Format("{0}({1})", creatureName, addToArmyNumber));

            var battleManager = new BattleManager(stubFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);
            battleManager.AddCreatures(creatureIdentifier, 1);

            var firstArmyCreatures = (ICollection<ICreaturesInBattle>)battleManagerAsPrivateObject.GetField("firstArmyCreatures");
            var creaturesInBattleAdded = firstArmyCreatures.First();

            var actualCreatureType = creaturesInBattleAdded.Creature.GetType();
            var expectedCreatureType = typeof(FakeCreature);

            Assert.AreEqual(expectedCreatureType, actualCreatureType);
        }

        [Test]
        public void CallILoggerWriteLineWithTheCorrectString()
        {
            var actualString = string.Empty;
            var expectedStringArmyFormat = "Creature added to army {0}";
            var expectedStringFormat = "--- {0} - {1}";

            var fakeCreature = new FakeCreature();

            var stubFactory = new Mock<ICreaturesFactory>();
            stubFactory.Setup(factory => factory.CreateCreature(It.IsAny<string>())).Returns(fakeCreature);

            var fakeLogger = new Mock<ILogger>();
            fakeLogger.Setup(logger => logger.WriteLine(It.IsAny<string>())).Callback((string input) => actualString = input);

            var creatureName = "fake";
            var addToArmyNumber = "1";
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(string.Format("{0}({1})", creatureName, addToArmyNumber));

            var battleManager = new BattleManager(stubFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);
            battleManager.AddCreatures(creatureIdentifier, 1);

            var expectedString = string.Format(expectedStringFormat, string.Format(expectedStringArmyFormat, addToArmyNumber), fakeCreature);

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
