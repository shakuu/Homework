namespace ArmyOfCreatures.Tests.Logic.BattleManagerTests
{
    using System;

    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    public class Attack_Should
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
    }
}
