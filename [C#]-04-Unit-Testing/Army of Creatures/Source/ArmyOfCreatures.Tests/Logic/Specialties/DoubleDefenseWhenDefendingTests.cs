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
    }
}
