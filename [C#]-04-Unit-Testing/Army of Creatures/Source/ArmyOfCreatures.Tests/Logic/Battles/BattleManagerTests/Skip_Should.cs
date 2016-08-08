namespace ArmyOfCreatures.Tests.Logic.Battles.BattleManagerTests
{
    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    public class Skip_Should
    {
        [Test]
        public void ShouldThrow_ArgumentExceptionWithCorrectMessage_WhenCreatureWasNotFound()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("creature(1)");
            var manager = new OverriddenGetByIdentifierBattleManager(mockFactory.Object, mockLogger.Object, null, null);

            Assert.That(() => manager.Skip(identifier), Throws.ArgumentException.With.Message.Contains("Skip creature not found:"));
        }

        [Test]
        public void ShouldAccessCreatureStartNewTurnTwice_WhenInputParametersAreCorrect()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("creature(1)");
            var mockCreatureInBattle = new Mock<ICreaturesInBattle>();
            var manager = new OverriddenGetByIdentifierBattleManager(mockFactory.Object, mockLogger.Object, mockCreatureInBattle.Object, null);

            manager.Skip(identifier);

            mockCreatureInBattle.Verify(mock => mock.StartNewTurn(), Times.Exactly(2));
        }

        [Test]
        public void ShouldAccessCreatureSkip_WhenInputParametersAreCorrect()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("creature(1)");
            var mockCreatureInBattle = new Mock<ICreaturesInBattle>();
            var manager = new OverriddenGetByIdentifierBattleManager(mockFactory.Object, mockLogger.Object, mockCreatureInBattle.Object, null);

            manager.Skip(identifier);

            mockCreatureInBattle.Verify(mock => mock.Skip(), Times.Once());
        }

        [Test]
        public void ShouldAccessLoggerWeiteLineTwice_WhenInputParametersAreCorrect()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("creature(1)");
            var mockCreatureInBattle = new Mock<ICreaturesInBattle>();
            var manager = new OverriddenGetByIdentifierBattleManager(mockFactory.Object, mockLogger.Object, mockCreatureInBattle.Object, null);

            manager.Skip(identifier);

            mockLogger.Verify(mock => mock.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
