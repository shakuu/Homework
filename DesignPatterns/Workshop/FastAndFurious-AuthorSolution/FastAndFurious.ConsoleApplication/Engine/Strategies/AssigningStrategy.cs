using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class AssigningStrategy : Strategy
    {
        private readonly ICommand command;

        public AssigningStrategy(ICommand command)
        {
            this.command = command;
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

            if (command.IsCommand(commandParameters))
            {
                command.ExecuteCommand(commandParameters, engineCollections);
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
