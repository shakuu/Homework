namespace ArmyOfCreatures.Tests.Logic.Battles
{
    using System;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void Constructor_ShouldAssignCorrectValues()
        {
            var creature = new FakeCreature();
            var count = 10;

            var actualCreaturesInBattle = new CreaturesInBattle(creature, count);

            Assert.That(actualCreaturesInBattle,
                Is.InstanceOf<CreaturesInBattle>()
                .With.Property("Creature").SameAs(creature)
                .And.Property("PermanentAttack").EqualTo(creature.Attack)
                .And.Property("PermanentDefense").EqualTo(creature.Defense)
                .And.Property("TotalHitPoints").EqualTo(creature.HealthPoints * count));
        }

        [Test]
        public void TotalHitPoints_GetShouldReturnZero_WhenTotalHitPointsFieldValueIsLessthanZero()
        {
            var creature = new FakeCreature();
            var count = 10;

            var creaturesInBattle = new CreaturesInBattle(creature, count);
            var creaturesInBattleAsPrivateObject = new MSTest.PrivateObject(creaturesInBattle);

            creaturesInBattleAsPrivateObject.SetField("totalHitPoints", int.MinValue);
            var actualTotalHitPoints = creaturesInBattle.TotalHitPoints;

            Assert.That(actualTotalHitPoints, Is.EqualTo(0));
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(5)]
        [TestCase(1892)]
        public void Count_GetShouldReturnCorrectValue(int totalHitPoints)
        {
            var creature = new FakeCreature();
            var count = 10;

            var creaturesInBattle = new CreaturesInBattle(creature, count);
            var creaturesInBattleAsPrivateObject = new MSTest.PrivateObject(creaturesInBattle);

            creaturesInBattleAsPrivateObject.SetField("totalHitPoints", totalHitPoints);
            var expectedCount = (int)Math.Ceiling((double)totalHitPoints / creature.HealthPoints);
            var actualCount = creaturesInBattle.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Count_GetShouldReturnZero_WhenActualValueIsLessthanZero(int totalHitPoints)
        {
            var creature = new FakeCreature();
            var count = 10;

            var creaturesInBattle = new CreaturesInBattle(creature, count);
            var creaturesInBattleAsPrivateObject = new MSTest.PrivateObject(creaturesInBattle);

            creaturesInBattleAsPrivateObject.SetField("totalHitPoints", totalHitPoints);
            var actualCount = creaturesInBattle.Count;

            Assert.That(actualCount, Is.EqualTo(0));
        }
    }
}
