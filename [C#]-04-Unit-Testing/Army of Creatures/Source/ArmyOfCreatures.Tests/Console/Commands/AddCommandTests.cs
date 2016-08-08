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

        //ProcessCommand should throw ArgumentNullException, 
        //when the "IBattleManager battleManager" is null.
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenIBattleManagerBattleManagerIsNull()
        {
            IBattleManager manager = null;
            string[] arguments = null;

            var command = new AddCommand();

            Assert.That(() => command.ProcessCommand(manager, arguments),
                Throws.ArgumentNullException.With.Message.Contains("battleManager"));
        }

        //ProcessCommand should throw ArgumentNullException,
        //when the "params string[] arguments" is null.
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenStringArrayArgumentsParameterIsNull()
        {
            var manager = new Mock<IBattleManager>();
            string[] arguments = null;

            var command = new AddCommand();

            Assert.That(() => command.ProcessCommand(manager.Object, arguments),
                Throws.ArgumentNullException.With.Message.Contains("arguments"));
        }

        //ProcessCommand should throw ArgumentNullException, 
        //when the number of "params string[] arguments" is invalid(lower than 2).
        [TestCase()]
        [TestCase("arg1")]
        public void ProcessCommand_ShouldThrowArgumentException_WhenStringArrayArgumentsParameterHasLenghtLessThanTwo(params string[] arguments)
        {
            var manager = new Mock<IBattleManager>();

            var command = new AddCommand();

            Assert.That(() => command.ProcessCommand(manager.Object, arguments),
                Throws.ArgumentException.With.Message.Contains("Invalid number of arguments for add command"));
        }

        //ProcessCommand should call IBattleManager.AddCreatures(), 
        //when the command is parsed successfully.
        [Test]
        public void ProcessCommand_ShouldCallIBattleManagerAddCreatures_WhenCommandIsParsedSuccessfully()
        {
            var manager = new Mock<IBattleManager>();
            var arguments = new[] { "10", "creature(1)" };

            var command = new AddCommand();
            command.ProcessCommand(manager.Object, arguments);

            manager.Verify(mock => mock.AddCreatures(
                It.Is<CreatureIdentifier>(ci => ci.CreatureType == "creature" && ci.ArmyNumber == 1),
                It.Is<int>(i => i == 10)),
                Times.Once());
        }
    }
}
