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

        [Test]
        public void CommandsDictionary_ShouldContainKeyAddCorrespondingToAddCommandType()
        {
            var manager = new CommandManager();
            var managetAsPrivateObject = new MSTest.PrivateObject(manager);
            var existingDictionary = (Dictionary<string, ICommand>)managetAsPrivateObject.GetField("commands");

            var key = "add";
            var actualValue = existingDictionary[key];

            Assert.That(actualValue, Is.InstanceOf<AddCommand>());
        }

        [Test]
        public void CommandsDictionary_ShouldContainKeyAttackCorrespondingToAttackCommandType()
        {
            var manager = new CommandManager();
            var managetAsPrivateObject = new MSTest.PrivateObject(manager);
            var existingDictionary = (Dictionary<string, ICommand>)managetAsPrivateObject.GetField("commands");

            var key = "attack";
            var actualValue = existingDictionary[key];

            Assert.That(actualValue, Is.InstanceOf<AttackCommand>());
        }

        [Test]
        public void CommandsDictionary_ShouldContainKeySkipCorrespondingToSkipCommandType()
        {
            var manager = new CommandManager();
            var managetAsPrivateObject = new MSTest.PrivateObject(manager);
            var existingDictionary = (Dictionary<string, ICommand>)managetAsPrivateObject.GetField("commands");

            var key = "skip";
            var actualValue = existingDictionary[key];

            Assert.That(actualValue, Is.InstanceOf<SkipCommand>());
        }

        [Test]
        public void CommandsDictionary_ShouldContainKeyExitCorrespondingToExitCommandType()
        {
            var manager = new CommandManager();
            var managetAsPrivateObject = new MSTest.PrivateObject(manager);
            var existingDictionary = (Dictionary<string, ICommand>)managetAsPrivateObject.GetField("commands");

            var key = "exit";
            var actualValue = existingDictionary[key];

            Assert.That(actualValue, Is.InstanceOf<ExitCommand>());
        }
    }
}
