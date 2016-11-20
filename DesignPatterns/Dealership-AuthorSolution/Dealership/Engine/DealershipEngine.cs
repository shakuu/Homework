using System;
using System.Collections.Generic;
using System.Text;

using Dealership.CommandHandlers.Contracts;
using Dealership.Common.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private readonly ICommandFactory factory;
        private readonly IIOProvider uiProvider;
        private readonly ICommandHandler commandHandler;

        public DealershipEngine(ICommandFactory factory, IIOProvider uiProvider, ICommandHandler commandHandler)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (uiProvider == null)
            {
                throw new ArgumentNullException(nameof(uiProvider));
            }

            if (commandHandler == null)
            {
                throw new ArgumentNullException(nameof(commandHandler));
            }

            this.factory = factory;
            this.uiProvider = uiProvider;
            this.commandHandler = commandHandler;
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IEnumerable<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.uiProvider.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.factory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.uiProvider.ReadLine();
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.uiProvider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            return this.commandHandler.HandleCommand(command);
        }
    }
}
