using FastAndFurious.ConsoleApplication.Engine.Contracts;

using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace FastAndFurious.ConsoleApplication.Tests.Engine
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Start_ShouldInvokeIInputOutputProviderReadLineMethod()
        {
            var fakeIOProvider = new Mock<IInputOutputProvider>();
            var fakeStrategy = new Mock<IStrategy>();

            var exitCommand = "-exit";
            fakeIOProvider.Setup(io => io.ReadLine()).Returns(exitCommand);

            var engine = new ConsoleApplication.Engine.Engine(fakeStrategy.Object, fakeIOProvider.Object);
            engine.Start();

            fakeIOProvider.Verify(io => io.ReadLine(), Times.Once);
        }

        [Test]
        public void Start_ShouldInvokeIStrategyExecuteStrategyMethod_WithCorrectParameters()
        {
            var fakeIOProvider = new Mock<IInputOutputProvider>();
            var fakeStrategy = new Mock<IStrategy>();

            var exitCommand = new List<string>() { "command word", "-exit" };
            var commandIndex = 0;
            fakeIOProvider.Setup(io => io.ReadLine()).Returns(() =>
            {
                return exitCommand[commandIndex++];
            });

            var engine = new ConsoleApplication.Engine.Engine(fakeStrategy.Object, fakeIOProvider.Object);
            engine.Start();

            fakeStrategy.Verify(s => s.Execute(new[] { "command", "word" }, It.IsAny<IEngineCollections>()), Times.Once());
        }
    }
}
