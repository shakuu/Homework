namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void Constructor_ShouldThrow_IfRoundsParameterIsLessThanOrEqualToZero(int rounds)
        {
            var resultingException = Assert.Throws<ArgumentOutOfRangeException>(() => new DoubleDefenseWhenDefending(rounds));
            Assert.IsTrue(resultingException.Message.Contains("The number of rounds should be greater than 0"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(int.MaxValue)]
        public void Constructor_ShouldAssignRoundsParameterValueToPrivateFieldRounds_IfRoundsParameterHasCorrectValue(int rounds)
        {
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);
            var doubleDefenseWhenDefendingAsPrivateObject = new MSTest.PrivateObject(doubleDefenseWhenDefending);

            var actualValue = (int)doubleDefenseWhenDefendingAsPrivateObject.GetField("rounds");

            Assert.AreEqual(rounds, actualValue);
        }

        [Test]
        public void ApplyWhenDefending_ShouldThrowTheCorrectErrorMessage_IfDefenderWithSpecialtyParameterIsNull()
        {
            ICreaturesInBattle defenderWithSpecialty = null;
            var attacker = new Mock<ICreaturesInBattle>();
            var rounds = 5;

            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            var resultingException = Assert.Throws<ArgumentNullException>(() => doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty, attacker.Object));
            Assert.IsTrue(resultingException.Message.Contains("defenderWithSpecialty"));
        }

        [Test]
        public void ApplyWhenDefending_ShouldThrowTheCorrectErrorMessage_IfAttackerParameterIsNull()
        {
            var defenderWithSpecialty = new Mock<ICreaturesInBattle>();
            ICreaturesInBattle attacker = null;
            var rounds = 5;

            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            var resultingException = Assert.Throws<ArgumentNullException>(() => doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty.Object, attacker));
            Assert.IsTrue(resultingException.Message.Contains("attacker"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void AppleWhenDefending_ShouldApplyEffect_AsManyTimesAsSPecifiedByTheRoundsParameter(int rounds)
        {
            var defenderWithSpecialty = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();

            defenderWithSpecialty.SetupGet(creature => creature.CurrentDefense).Returns(0);
            defenderWithSpecialty.SetupSet(creature => creature.CurrentDefense = 0);

            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            for (var i = 0; i <= rounds * 2; i++)
            {
                doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty.Object, attacker.Object);
            }

            defenderWithSpecialty.VerifySet(creature => creature.CurrentDefense = It.IsAny<int>(), Times.Exactly(rounds));
        }

        [Test]
        public void ApplyWhenDefending_ShouldDecrementFieldRounds_WhenRoundsIsLargerThanZero()
        {
            var defenderWithSpecialty = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();

            var rounds = 5;
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            var doubleDefenseWhenDefendingAsPrivateObject = new MSTest.PrivateObject(doubleDefenseWhenDefending);
            var initialNumberOfRounds = doubleDefenseWhenDefendingAsPrivateObject.GetField("rounds");
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty.Object, attacker.Object);
            var actualNumberOfRounds = doubleDefenseWhenDefendingAsPrivateObject.GetField("rounds");

            Assert.AreEqual(rounds - 1, actualNumberOfRounds);
        }

        [Test]
        public void ApplyWhenDefending_ShouldNotDecrementFieldRounds_WhenRoundsIsEqualToZero()
        {
            var defenderWithSpecialty = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();

            var rounds = 1;
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            var doubleDefenseWhenDefendingAsPrivateObject = new MSTest.PrivateObject(doubleDefenseWhenDefending);
            var initialNumberOfRounds = doubleDefenseWhenDefendingAsPrivateObject.GetField("rounds");
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty.Object, attacker.Object);
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty.Object, attacker.Object);
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecialty.Object, attacker.Object);
            var actualNumberOfRounds = doubleDefenseWhenDefendingAsPrivateObject.GetField("rounds");

            Assert.AreEqual(0, actualNumberOfRounds);
        }

        [Test]
        public void ApplyWhenDefending_ShouldApplyEffectToICreaturesInBattleDefenderWithSpecialtyCurrentDefense()
        {
            var defenderWithSpecilty = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();

            var rounds = 5;
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            var defense = 1;
            defenderWithSpecilty.SetupGet(mock => mock.CurrentDefense).Returns(defense);
            defenderWithSpecilty.SetupSet(mock => mock.CurrentDefense = It.IsAny<int>());

            doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecilty.Object, attacker.Object);

            defenderWithSpecilty.VerifySet(mock => mock.CurrentDefense = It.Is<int>(i => i == defense * 2), Times.Once());
        }

        [Test]
        public void ApplyWhenDefending_ShouldNotApplyEffectToAttacker()
        {
            var defenderWithSpecilty = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>(MockBehavior.Strict);

            var rounds = 5;
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(rounds);

            defenderWithSpecilty.SetupGet(mock => mock.CurrentDefense).Returns(0);
            defenderWithSpecilty.SetupSet(mock => mock.CurrentDefense = It.IsAny<int>());

            doubleDefenseWhenDefending.ApplyWhenDefending(defenderWithSpecilty.Object, attacker.Object);

            attacker.Verify();
        }
    }
}
