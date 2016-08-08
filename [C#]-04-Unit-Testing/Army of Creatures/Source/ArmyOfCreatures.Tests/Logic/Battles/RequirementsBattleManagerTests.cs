namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System.Reflection;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;
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
        [Test]
        public void AddCreatures_ShouldThrowArgumentException_WhenAttemptingToAddCreatureToArmyNumberThree()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            mockFactory.Setup(mock => mock.CreateCreature(It.IsAny<string>())).Returns(new FakeCreature());
            var mockLogger = new Mock<ILogger>();

            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var creatureIdenifier = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "creature", 3 });
            var count = 10;

            var manager = new BattleManager(mockFactory.Object, mockLogger.Object);

            Assert.That(() => manager.AddCreatures(creatureIdenifier, count),
                Throws.ArgumentException.With.Message.Contains("Invalid ArmyNumber: "));
        }

        //Attacking with null identifier should throw ArgumentNullException
        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenAttackerIdentifierParameterIsNull()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();

            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                   .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var defender = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "creature", 3 });

            CreatureIdentifier attacker = null;

            var manager = new BattleManager(mockFactory.Object, mockLogger.Object);

            Assert.That(() => manager.Attack(attacker, defender),
                Throws.ArgumentNullException.With.Message.Contains("identifier"));
        }

        //Attacking with null unit should throw ArgumentException
        [Test]
        public void Attack_ShouldThrowArgumentException_WhenAttackerIdentifierDoesNotMatchACreaturesInBattle()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();

            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                   .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var defender = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "creature", 1 });
            var attacker = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "different", 2 });

            var manager = new BattleManager(mockFactory.Object, mockLogger.Object);

            Assert.That(() => manager.Attack(attacker, defender),
                Throws.ArgumentException.With.Message.Contains("Attacker not found:"));
        }

        //Attacking successful should call WriteLine from Logger exactly 4 times
        [Test]
        public void Attack_ShouldCallILoggerWriteLineFourTimes_WhenInputParamtersAreValid()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();

            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                   .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var defender = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "creature", 1 });
            var attacker = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "different", 2 });

            var mockAttackerCreaturesInBattle = new Mock<ICreaturesInBattle>();
            mockAttackerCreaturesInBattle.SetupGet(mock => mock.Creature).Returns(new FakeCreature());
            var mockDefenderCreaturesInBattle = new Mock<ICreaturesInBattle>();
            mockDefenderCreaturesInBattle.SetupGet(mock => mock.Creature).Returns(new FakeCreature());

            var manager = new OverriddenGetByIdentifierBattleManager(
                mockFactory.Object, mockLogger.Object, mockAttackerCreaturesInBattle.Object, mockDefenderCreaturesInBattle.Object);

            manager.Attack(attacker, defender);

            mockLogger.Verify(mock => mock.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        //Attacking with two Behemoths should return right result
        //(two Behemoths attack 1 Behemoth and the expected result is 56) -
        //could be tried with all the other creatures
        [Test]
        public void Attack_TwoBehemothsAttackingOneBehemothShouldResultInDefenderHavingFiftySixHitPointsLeft()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();

            var creatureIdentifierConstructor = typeof(CreatureIdentifier)
                   .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(int) }, null);
            var defender = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "creature", 1 });
            var attacker = (CreatureIdentifier)creatureIdentifierConstructor.Invoke(new object[] { "different", 2 });

            var attackerCreaturesInBattle = new CreaturesInBattle(new Behemoth(), 2);
            var defenderCreaturesInBattle = new CreaturesInBattle(new Behemoth(), 1);

            var manager = new OverriddenGetByIdentifierBattleManager(
                mockFactory.Object, mockLogger.Object, attackerCreaturesInBattle, defenderCreaturesInBattle);

            manager.Attack(attacker, defender);

            Assert.That(defenderCreaturesInBattle.TotalHitPoints, Is.EqualTo(56));
        }
    }
}
