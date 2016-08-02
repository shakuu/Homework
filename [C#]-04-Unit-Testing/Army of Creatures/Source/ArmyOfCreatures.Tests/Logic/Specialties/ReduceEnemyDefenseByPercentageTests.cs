namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    [TestFixture]
    public class ReduceEnemyDefenseByPercentageTests
    {
        [Test]
        public void Constructor_ShouldThrowWithCorrectMessage_IfPercentageParameterIsLessThanZero()
        {
            var percentage = -0.05m;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new ReduceEnemyDefenseByPercentage(percentage));
            StringAssert.Contains("The percentage argument should be between 0 and 100, inclusive", exception.Message);
        }

        [Test]
        public void Constructor_ShouldThrowWithCorrectMessage_IfPercentageParameterIsLargerhanOneHundered()
        {
            var percentage = 100.000000001m;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new ReduceEnemyDefenseByPercentage(percentage));
            StringAssert.Contains("The percentage argument should be between 0 and 100, inclusive", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetTheCorrectValueToPercentageField()
        {
            var expectedPercentage = 50m;
            var specialty = new ReduceEnemyDefenseByPercentage(expectedPercentage);

            var specialtyAsPrivateObject = new MSTest.PrivateObject(specialty);
            var actualPercentage = specialtyAsPrivateObject.GetProperty("Percentage");

            Assert.AreEqual(expectedPercentage, actualPercentage);
        }

        [Test]
        public void ApplyWhenAttacking_ShouldThrowWithCorrectMessage_IfAttackerWithSpecialtyParameterIsNull()
        {
            ICreaturesInBattle attackerWithSpecialty = null;
            var defender = new Mock<ICreaturesInBattle>();
            var percentage = 50m;
            var specialty = new ReduceEnemyDefenseByPercentage(percentage);

            var exception = Assert.Throws<ArgumentNullException>(() => specialty.ApplyWhenAttacking(attackerWithSpecialty, defender.Object));
            StringAssert.Contains("attackerWithSpecialty", exception.Message);
        }
    }
}
