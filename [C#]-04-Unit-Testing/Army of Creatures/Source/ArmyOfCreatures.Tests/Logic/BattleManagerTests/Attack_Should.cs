namespace ArmyOfCreatures.Tests.Logic.BattleManagerTests
{
    using System;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    public class BattleManagerAttack_Should
    {
        [Test]
        public void ThrowWithCorrectMessage_WhenAttackerIdentifierIsNull()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            CreatureIdentifier attacker = null;
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("fake(2)");

            var actualException = Assert.Throws<ArgumentNullException>(() => battleManager.Attack(attacker, defenderCreatureIdentifier));
            StringAssert.Contains("identifier", actualException.Message);
        }

        [Test]
        public void ThrowWithCorrectMessage_WhenDefenderIdentifierIsNull()
        {
            var attackerCreature = new FakeCreature();
            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(factory => factory.CreateCreature(It.IsAny<string>())).Returns(attackerCreature);

            var fakeLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)"); ;
            CreatureIdentifier defender = null;

            battleManager.AddCreatures(attackerCreatureIdentifier, 10);

            var actualException = Assert.Throws<ArgumentNullException>(() => battleManager.Attack(attackerCreatureIdentifier, defender));
            StringAssert.Contains("identifier", actualException.Message);
        }

        [Test]
        public void ThrowWithCorrectMessage_IfCreatureArmyNumberIsNotOneOrTwo()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(factory => factory.CreateCreature(It.IsAny<string>())).Returns(new FakeCreature());

            var fakeLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            var attackerCreatureIndentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var incorrectAttackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(3)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(2)");

            battleManager.AddCreatures(attackerCreatureIndentifier, 10);
            battleManager.AddCreatures(defenderCreatureIdentifier, 100);

            var actualException = Assert.Throws<ArgumentException>(() =>
                battleManager.Attack(incorrectAttackerCreatureIdentifier, defenderCreatureIdentifier));
            StringAssert.Contains("Invalid ArmyNumber: 3", actualException.Message);
        }

        [Test]
        public void ThrowWithCorrectMessage_IfAttackerWasNotFoundInTheSpecifiedArmy()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(factory => factory.CreateCreature(It.IsAny<string>())).Returns(new DifferentFakeCreature());

            var fakeLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            var attackerCreatureIndentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(1)");
            var incorrectAttackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            battleManager.AddCreatures(attackerCreatureIndentifier, 10);
            battleManager.AddCreatures(defenderCreatureIdentifier, 100);

            var actualException = Assert.Throws<ArgumentException>(() =>
                battleManager.Attack(incorrectAttackerCreatureIdentifier, defenderCreatureIdentifier));
            StringAssert.Contains("Attacker not found: FakeCreature(1)", actualException.Message);
        }

        [Test]
        public void ThrowWithCorrectMessage_IfDefenderWasNotFoundInTheSpecifiedArmy()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            fakeFactory.Setup(factory => factory.CreateCreature(It.IsAny<string>())).Returns(new DifferentFakeCreature());

            var fakeLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            var attackerCreatureIndentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(1)");
            var incorrectDefenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(2)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            battleManager.AddCreatures(attackerCreatureIndentifier, 10);
            battleManager.AddCreatures(defenderCreatureIdentifier, 100);

            var actualException = Assert.Throws<ArgumentException>(() =>
                battleManager.Attack(attackerCreatureIndentifier, incorrectDefenderCreatureIdentifier));
            StringAssert.Contains("Defender not found: FakeCreature(2)", actualException.Message);
        }

        [Test]
        public void CallAttackerCreatureStartNewTurn_IfTheProvidedParametersAreCorrect()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(new FakeCreature());

            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(new DifferentFakeCreature());

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);

            attackerInBattle.Verify(creature => creature.StartNewTurn(), Times.Once());
        }

        [Test]
        public void CallDefenderCreatureStartNewTurn_IfTheProvidedParametersAreCorrect()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(new FakeCreature());

            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(new DifferentFakeCreature());

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);

            defenderInBattle.Verify(creature => creature.StartNewTurn(), Times.Once());
        }

        [Test]
        public void CallAttackerCreatureDealDamage()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(new FakeCreature());

            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(new DifferentFakeCreature());

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);

            attackerInBattle.Verify(creature => creature.DealDamage(It.IsAny<ICreaturesInBattle>()), Times.Once());
        }

        [Test]
        public void CallILoggerWriteLineExactlyFourTimes()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();
            fakeLogger.Setup(logger => logger.WriteLine(It.IsAny<string>()));

            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(new FakeCreature());

            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(new DifferentFakeCreature());

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);

            fakeLogger.Verify(creature => creature.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void CallILoggerWriteLineExactlyFourTimesWithCorrectMessages()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();
            fakeLogger.Setup(logger => logger.WriteLine(It.IsAny<string>()));

            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(new FakeCreature());

            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(new DifferentFakeCreature());

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);

            fakeLogger.Verify(creature => creature.WriteLine(It.Is<string>(str => str.Contains("Attacker before"))), Times.Exactly(1));
            fakeLogger.Verify(creature => creature.WriteLine(It.Is<string>(str => str.Contains("Defender before"))), Times.Exactly(1));
            fakeLogger.Verify(creature => creature.WriteLine(It.Is<string>(str => str.Contains("Attacker after"))), Times.Exactly(1));
            fakeLogger.Verify(creature => creature.WriteLine(It.Is<string>(str => str.Contains("Defender after"))), Times.Exactly(1));
        }


        [Test]
        public void ApplyAttackerCreatureApplyWhenAttackingSpecilty()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var attackerCreature = new FakeCreature();
            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(attackerCreature);

            var defenderCreature = new DifferentFakeCreature();
            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(defenderCreature);

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);
            var attackerSpecialty = (FakeSpecialty)attackerCreature.Specialties.First();

            Assert.IsTrue(attackerSpecialty.MethodsAccessedAsAttackerAreCalled);
        }

        [Test]
        public void ApplyDefenderCreatureApplyWhenAttackingSpecilty()
        {
            var fakeFoctory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();

            var attackerCreature = new FakeCreature();
            var attackerInBattle = new Mock<ICreaturesInBattle>();
            attackerInBattle.SetupGet(attacker => attacker.Creature).Returns(attackerCreature);

            var defenderCreature = new DifferentFakeCreature();
            var defenderInBattle = new Mock<ICreaturesInBattle>();
            defenderInBattle.SetupGet(attacker => attacker.Creature).Returns(defenderCreature);

            var overriddenBattleManager = new OverriddenGetByIdentifierBattleManager(
                fakeFoctory.Object, fakeLogger.Object, attackerInBattle.Object, defenderInBattle.Object);
            var attackerCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("FakeCreature(1)");
            var defenderCreatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("DifferentFakeCreature(2)");

            overriddenBattleManager.Attack(attackerCreatureIdentifier, defenderCreatureIdentifier);
            var defenderSpecialty = (FakeSpecialty)defenderCreature.Specialties.First();

            Assert.IsTrue(defenderSpecialty.MethodsAccessedAsDefenderAreCalled);
        }
    }
}
