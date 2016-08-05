namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System.Collections.Generic;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class BattleManagerConstructor_Should
    {
        [Test]
        public void InitializeFirstArmyCreaturesCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualFirstArmyCreatures = battleManagerAsPrivateObject.GetField("firstArmyCreatures");

            Assert.IsTrue(actualFirstArmyCreatures is ICollection<ICreaturesInBattle>);
        }

        [Test]
        public void InitializeSecondArmyCreaturesCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualSecondArmyCreatures = battleManagerAsPrivateObject.GetField("secondArmyCreatures");

            Assert.IsTrue(actualSecondArmyCreatures is ICollection<ICreaturesInBattle>);
        }

        [Test]
        public void InitializeCreatureFactoryCorrectly()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);
            var battleManagerAsPrivateObject = new MSTest.PrivateObject(battleManager);

            var actualCreaturesFactory = battleManagerAsPrivateObject.GetField("creaturesFactory");

            Assert.IsTrue(actualCreaturesFactory is ICreaturesFactory);
        }

        [Test]
        public void InitializeLoggerCorrectly()
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
