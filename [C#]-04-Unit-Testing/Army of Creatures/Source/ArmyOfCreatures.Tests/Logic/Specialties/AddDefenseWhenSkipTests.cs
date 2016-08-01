namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using Moq;
    using msTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    [TestFixture]
    public class AddDefenseWhenSkipTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(21)]
        public void Constructor_ShouldThrow_IfPassedValueIsOutsideTheGivenRange(int defenseToAdd)
        {
            var resultingException = Assert.Throws<ArgumentOutOfRangeException>(() => new AddDefenseWhenSkip(defenseToAdd));
            Assert.IsTrue(resultingException.Message.Contains("defenseToAdd should be between 1 and 20, inclusive"));
        }

        [Test]
        public void ApplyOnSkip_ShouldThrow_IfPassedICreaturesInBattleParameterIsNull()
        {
            ICreaturesInBattle creaturesInBattle = null;
            var addDefenseWhenSkip = new AddDefenseWhenSkip(5);

            var resultingException = Assert.Throws<ArgumentNullException>(() => addDefenseWhenSkip.ApplyOnSkip(creaturesInBattle));
            Assert.IsTrue(resultingException.Message.Contains("skipCreature"));
        }

        [Test]
        public void ApplyOnSkip_ShouldAssignTheCorrectValue_WhenPassedAValidParameter()
        {
            var expectedDefenseToAdd = 5;
            var addDefenseWhenSkip = new AddDefenseWhenSkip(expectedDefenseToAdd);
            var privateAddDefenseOnSkip = new msTest.PrivateObject(addDefenseWhenSkip);

            var actualValue = privateAddDefenseOnSkip.GetField("defenseToAdd");

            Assert.AreEqual(expectedDefenseToAdd, actualValue);
        }

        [Test]
        public void ApplyOnSkip_ShouldAccessICreaturesInBattlePermanentDefenseSetter()
        {
            var creaturesInBattle = new Mock<ICreaturesInBattle>();
            creaturesInBattle.SetupGet(creature => creature.PermanentDefense).Returns(0);
            creaturesInBattle.SetupSet(creature => creature.PermanentDefense = 0);

            var addDefenseWhenSkip = new AddDefenseWhenSkip(5);
            addDefenseWhenSkip.ApplyOnSkip(creaturesInBattle.Object);

            creaturesInBattle.Verify(creature => creature.PermanentDefense, Times.Once);
        }

        [Test]
        public void ApplyAfterDefending_ShouldNotChangeAnyICreaturesInBattleProperties()
        {
            var creaturesInBattle = new Mock<ICreaturesInBattle>(MockBehavior.Strict);

            var addDefenseWhenSkip = new AddDefenseWhenSkip(5);
            addDefenseWhenSkip.ApplyAfterDefending(creaturesInBattle.Object);

            creaturesInBattle.VerifyAll();
        }

        [Test]
        public void ApplyWhenAttacking_ShouldNotChangeAnyICreaturesInBattleProperties()
        {
            var attacker = new Mock<ICreaturesInBattle>(MockBehavior.Strict);
            var defender = new Mock<ICreaturesInBattle>();

            var addDefenseWhenSkip = new AddDefenseWhenSkip(5);
            addDefenseWhenSkip.ApplyWhenAttacking(attacker.Object, defender.Object );

            attacker.VerifyAll();
        }

        [Test]
        public void ApplyWhenDefending_ShouldNotChangeAnyICreaturesInBattleProperties()
        {
            var attacker = new Mock<ICreaturesInBattle>(MockBehavior.Strict);
            var defender = new Mock<ICreaturesInBattle>();

            var addDefenseWhenSkip = new AddDefenseWhenSkip(5);
            addDefenseWhenSkip.ApplyWhenDefending(attacker.Object, defender.Object);

            attacker.VerifyAll();
        }

        [Test]
        public void ChangeDamageWhenAttacking_ShouldNotChangeAnyICreaturesInBattleProperties()
        {
            var attacker = new Mock<ICreaturesInBattle>(MockBehavior.Strict);
            var defender = new Mock<ICreaturesInBattle>();

            var addDefenseWhenSkip = new AddDefenseWhenSkip(5);
            addDefenseWhenSkip.ChangeDamageWhenAttacking(attacker.Object, defender.Object, 1m);

            attacker.VerifyAll();
        }
    }
}
