namespace ArmyOfCreatures.Tests.Console.Commands
{
    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Logic.Battles;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AttackCommandTests
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenIBattleManagerParameterIsNull()
        {
            IBattleManager mockBattleManager = null;
            var arguments = new string[] { };

            var command = new AttackCommand();

            Assert.That(() => command.ProcessCommand(mockBattleManager, arguments),
                Throws.ArgumentNullException.With.Message.Contains("battleManager"));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenArgumentsParameterIsNull()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            string[] arguments = null;

            var command = new AttackCommand();

            Assert.That(() => command.ProcessCommand(mockBattleManager.Object, arguments),
                Throws.ArgumentNullException.With.Message.Contains("arguments"));
        }

        [TestCase()]
        [TestCase("one")]
        public void ProcessCommand_ShouldThrowArgumentException_WhenArgumentsParameterLengthIsLessThanTwo(params string[] arguments)
        {
            var mockBattleManager = new Mock<IBattleManager>();

            var command = new AttackCommand();

            Assert.That(() => command.ProcessCommand(mockBattleManager.Object, arguments),
                Throws.ArgumentException.With.Message.Contains("Invalid number of arguments for attack command"));
        }

        [Test]
        public void ProcessCommand_ShouldAccessIBattleManagerAttackWithCorrectParamters_WhenInputParametersAreCorrect()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            var attacker = "Archangel(2)";
            var defender = "Goblin(1)";

            var arguments = new[] { attacker, defender };

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString(attacker);
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString(defender);

            var command = new AttackCommand();
            command.ProcessCommand(mockBattleManager.Object, arguments);

            mockBattleManager.Verify(mock => mock.Attack(
                It.Is<CreatureIdentifier>(ci => ci.CreatureType == attackerIdentifier.CreatureType && ci.ArmyNumber == attackerIdentifier.ArmyNumber),
                It.Is<CreatureIdentifier>(ci => ci.CreatureType == defenderIdentifier.CreatureType && ci.ArmyNumber == defenderIdentifier.ArmyNumber)),
                Times.Once());
        }
    }
}
