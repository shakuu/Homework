namespace ArmyOfCreatures.Tests.Console.Commands
{
    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Logic.Battles;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenIBattleManagerParameterIsNull()
        {
            IBattleManager mockBattleManager = null;
            var arguments = new string[] { };

            var addCommand = new AddCommand();

            Assert.That(() => addCommand.ProcessCommand(mockBattleManager, arguments),
                Throws.ArgumentNullException.With.Message.Contains("battleManager"));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenArgumentsParameterIsNull()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            string[] arguments = null;

            var addCommand = new AddCommand();

            Assert.That(() => addCommand.ProcessCommand(mockBattleManager.Object, arguments),
                Throws.ArgumentNullException.With.Message.Contains("arguments"));
        }

        [TestCase()]
        [TestCase("first")]
        public void ProcessCommand_ShouldThrowArgumentException_WhenArgumentsParameterLengthIsLessThanTwo(params string[] arguments)
        {
            var mockBattleManager = new Mock<IBattleManager>();

            var addCommand = new AddCommand();

            Assert.That(() => addCommand.ProcessCommand(mockBattleManager.Object, arguments),
                Throws.ArgumentException.With.Message.Contains("Invalid number of arguments for add command"));
        }

        [Test]
        public void ProcessCommand_ShouldAccessIBattleManagerAddCreature_WhenInputParametersAreValid()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            var arguments = new[] { "10", "AncientBehemoth(1)" };
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            var addCommand = new AddCommand();
            addCommand.ProcessCommand(mockBattleManager.Object, arguments);

            mockBattleManager.Verify(mock => mock.AddCreatures(It.IsAny<CreatureIdentifier>(), 10), Times.Once());
        }

        [Test]
        public void ProcessCommand_ShouldAccessIBattleManagerAddCreatureWithCorrectCreatureIdentifier_WhenInputParametersAreValid()
        {
            var mockBattleManager = new Mock<IBattleManager>();
            var arguments = new[] { "10", "AncientBehemoth(1)" };
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("AncientBehemoth(1)");

            var addCommand = new AddCommand();
            addCommand.ProcessCommand(mockBattleManager.Object, arguments);

            mockBattleManager.Verify(
                mock => mock.AddCreatures(
                    It.Is<CreatureIdentifier>(ci => ci.CreatureType == "AncientBehemoth" && ci.ArmyNumber == 1), 10),
                    Times.Once());
        }
    }
}
