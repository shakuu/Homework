namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    public class HateTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_IfParameterCreatureTypeToHateIsNull()
        {
            Type type = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new Hate(type));
            StringAssert.Contains("creatureTypeToHate", exception.Message);
        }

        [Test]
        public void Constructor_ShouldAssignTheCorrectTypeToFieldCreatureTypeToHate()
        {
            var typeToHate = typeof(FakeCreature);
            var hate = new Hate(typeToHate);

            var hateAsPrivateObject = new MSTest.PrivateObject(hate);
            var actual = hateAsPrivateObject.GetField("creatureTypeToHate");

            Assert.AreEqual(typeToHate, actual);
        }

        [Test]
        public void ChangeDamageWhenAttacking_ShouldThrowWithCorrectMessage_WhenAttackerWithSpecialtyParameterIsNull()
        {
            ICreaturesInBattle attackerWithSpecialty = null;
            var defender = new Mock<ICreaturesInBattle>();
            var typeToHate = typeof(FakeCreature);
            var damage = 10m;

            var hate = new Hate(typeToHate);

            var exception = Assert.Throws<ArgumentNullException>(() => hate.ChangeDamageWhenAttacking(attackerWithSpecialty, defender.Object, damage));
            StringAssert.Contains("attackerWithSpecialty", exception.Message);
        }

        [Test]
        public void ChangeDamageWhenAttacking_ShouldThrowWithCorrectMessage_WhenDefenderParameterIsNull()
        {
            var attackerWithSpecialty = new Mock<ICreaturesInBattle>();
            ICreaturesInBattle defender = null;
            var typeToHate = typeof(FakeCreature);
            var damage = 10m;

            var hate = new Hate(typeToHate);

            var exception = Assert.Throws<ArgumentNullException>(() => hate.ChangeDamageWhenAttacking(attackerWithSpecialty.Object, defender, damage));
            StringAssert.Contains("defender", exception.Message);
        }

        [Test]
        public void ChangeDamageWhenAttacking_ShouldNotModifyDamage_IfDefenderTypeIsNotEqualToCreatureTypeToHate()
        {
            var attackerWithSpecialty = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();
            var typeToHate = typeof(FakeCreature);
            var expectedDamage = 10m;

            defender.SetupGet(mock => mock.Creature).Returns(new DifferentFakeCreature());

            var hate = new Hate(typeToHate);

            var actual = hate.ChangeDamageWhenAttacking(attackerWithSpecialty.Object, defender.Object, expectedDamage);

            Assert.AreEqual(expectedDamage, actual);
        }

        [Test]
        public void ChangeDamageWhenAttacking_ShouldReturnDamageLargerThanInputDamage_IfDefenderTypeIsEqualToCreatureTypeToHate()
        {
            var attackerWithSpecialty = new Mock<ICreaturesInBattle>();
            var defender = new Mock<ICreaturesInBattle>();
            var typeToHate = typeof(FakeCreature);
            var expectedDamage = 10m;

            defender.SetupGet(mock => mock.Creature).Returns(new FakeCreature());

            var hate = new Hate(typeToHate);

            var actual = hate.ChangeDamageWhenAttacking(attackerWithSpecialty.Object, defender.Object, expectedDamage);

            Assert.IsTrue(expectedDamage < actual);
        }
    }
}
