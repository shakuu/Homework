namespace ArmyOfCreatures.Tests.Console.Commands
{
    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Logic.Battles;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class SkipCommandTests
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenIBattleManagerParameterIsNull()
        {
            IBattleManager mockBattleManager = null;
            var arguments = new string[] { };

            var command = new SkipCommand();

            Assert.That(() => command.ProcessCommand(mockBattleManager, arguments),
                Throws.ArgumentNullException.With.Message.Contains("battleManager"));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenArgumentsParameterIsNull()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            string[] arguments = null;

            var command = new SkipCommand();

            Assert.That(() => command.ProcessCommand(mockBattleManager.Object, arguments),
                Throws.ArgumentNullException.With.Message.Contains("arguments"));
        }

        [TestCase()]
        public void ProcessCommand_ShouldThrowArgumentException_WhenArgumentParameterLengthIsLessThanOne(params string[] arguments)
        {
            var mockBattleManager = new Mock<IBattleManager>();

            var command = new SkipCommand();

            Assert.That(() => command.ProcessCommand(mockBattleManager.Object, arguments),
                Throws.ArgumentException.With.Message.Contains("Invalid number of arguments for skip command"));
        }

        [Test]
        public void ProcessCommand_ShouldCallIBattleManagerSkipWithCorrectCreatureIdentifier_WhenInputParamtersAreValid()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            var creature = "Archangel(2)";
            var arguments = new[] { creature };

            var command = new SkipCommand();
            command.ProcessCommand(mockBattleManager.Object, arguments);

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(creature);

            mockBattleManager.Verify(mock =>
                mock.Skip(It.Is<CreatureIdentifier>(ci =>
                    ci.CreatureType == creatureIdentifier.CreatureType
                    && ci.ArmyNumber == creatureIdentifier.ArmyNumber)),
                Times.Once());
        }
    }
}
