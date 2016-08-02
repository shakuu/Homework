namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;
    using System.Collections.Generic;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

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
    }
}
