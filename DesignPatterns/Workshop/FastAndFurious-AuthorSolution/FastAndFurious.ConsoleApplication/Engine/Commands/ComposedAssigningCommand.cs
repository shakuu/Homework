using System.Collections.Generic;
using System.Linq;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine.Commands
{
    public class ComposedAssigningCommand : AssigningCommand
    {
        private readonly IEnumerable<IAssigningCommand> commands;

        public ComposedAssigningCommand(IEnumerable<IAssigningCommand> commands)
        {
            this.commands = commands;
        }

        public override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var commandToExecute = this.commands.FirstOrDefault(c => c.IsCommand(commandParameters));
            if (commandToExecute != null)
            {
                commandToExecute.ExecuteCommand(commandParameters, engineCollections);
            }
        }

        public override bool IsCommand(IList<string> commandParameters)
        {
            return this.commands.Any(c => c.IsCommand(commandParameters));
        }
    }
}
