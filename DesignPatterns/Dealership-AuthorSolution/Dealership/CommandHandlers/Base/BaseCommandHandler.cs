using System.Collections.Generic;

using Dealership.CommandHandlers.Contracts;
using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;

namespace Dealership.CommandHandlers.Base
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private ICommandHandler nextHandler;

        public BaseCommandHandler(ICommandHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public string HandleCommand(ICommand command, ICollection<IUser> users, IDealershipFactory factory)
        {
            string result;
            if (this.CanHandle(command))
            {
                result = this.Handle(command);
            }
            else if (this.nextHandler != null)
            {
                result = this.nextHandler.HandleCommand(command, users, factory);
            }
            else
            {
                result = string.Format(InvalidCommand, command.Name);
            }

            return result;
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command);
    }
}
