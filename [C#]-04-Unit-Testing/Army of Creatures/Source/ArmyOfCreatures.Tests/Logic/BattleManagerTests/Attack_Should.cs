namespace ArmyOfCreatures.Tests.Logic.BattleManagerTests
{
    using System;

    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    [TestFixture]
    public class Attack_Should
    {
        [Test]
        public void Throw_WhenAttackerIdentifierIsNull()
        {
            var fakeFactory = new Mock<ICreaturesFactory>();
            var fakeLogger = new Mock<ILogger>();
            var manager = new BattleManager(fakeFactory.Object, fakeLogger.Object);

            CreatureIdentifier attacker = null;
            var defender = CreatureIdentifier.CreatureIdentifierFromString("fake(2)");

            Assert.Throws<ArgumentNullException>
        }
    }
}
