using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;
using System.Linq;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class AssigningStrategy : Strategy
    {
        private readonly IEnumerable<ICommand> commands;

        public AssigningStrategy(IEnumerable<IAssigningCommand> commands)
        {
            this.commands = commands;
        }

        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.AssigningStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var assignTypeCommand = commandParameters[1];
            var objectToAssignId = int.Parse(commandParameters[2]);
            var ownerToAssignToId = int.Parse(commandParameters[5]);

            var matchingCommand = this.commands.FirstOrDefault(c => c.IsCommand(commandParameters));
            if (matchingCommand != null)
            {
                matchingCommand.ExecuteCommand(commandParameters, engineCollections);
            }
            else
            {
                throw new NotSupportedException(GlobalConstants.AssigningOperationNotSupportedExceptionMessage);
            }
            
            engineCollections.IoProvider.WriteLine(
                String.Format(
                    GlobalConstants.ItemAssignedSuccessfullyMessage,
                    objectToAssignId,
                    ownerToAssignToId));
        }
    }
}
