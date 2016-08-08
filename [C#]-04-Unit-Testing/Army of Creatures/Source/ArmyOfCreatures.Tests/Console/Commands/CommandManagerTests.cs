namespace ArmyOfCreatures.Tests.Console.Commands
{
    using System.Collections.Generic;

    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Logic.Battles;

    using Moq;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    [TestFixture]
    public class CommandManagerTests
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenCommandLineParamterIsNull()
        {
            string commandLine = null;
            var mockBattleManager = new Mock<IBattleManager>();

            var manager = new CommandManager();

            Assert.That(() => manager.ProcessCommand(commandLine, mockBattleManager.Object),
                Throws.ArgumentNullException.With.Message.Contains("commandLine"));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentException_WhenCommandsDictionaryDoesNotContainInputCommand()
        {
            string commandLine = "unexistingCommand 50 Griffin(2)";
            var mockBattleManager = new Mock<IBattleManager>();

            var manager = new CommandManager();

            Assert.That(() => manager.ProcessCommand(commandLine, mockBattleManager.Object),
                Throws.ArgumentException.With.Message.Contains("Invalid command name"));
        }

        [Test]
        public void ProcessCommand_ShouldCallTheCorrectCommandFromCommandsDictionary_WhenInputParamtersAreValid()
        {
            var mockCommand = new Mock<ICommand>();
            var replacementDictionary = new Dictionary<string, ICommand>()
            {
                { "mockCommand", mockCommand.Object }
            };

            var mockBattleManager = new Mock<IBattleManager>();
            string commandLine = "mockCommand 50 Griffin(2)";

            var manager = new CommandManager();
            var managerAsPrivateObject = new MSTest.PrivateObject(manager);
            managerAsPrivateObject.SetField("commands", replacementDictionary);

            manager.ProcessCommand(commandLine, mockBattleManager.Object);

            mockCommand.Verify(mock => mock.ProcessCommand(
                It.Is<IBattleManager>(bm => bm.Equals(mockBattleManager.Object)),
                It.Is<string[]>(args => args.Length == 2 && args[0] == "50" && args[1] == "Griffin(2)")),
                Times.Once());
        }
    }
}
