using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers.Base
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private readonly ICommandHandler nextHandler;

        public BaseCommandHandler(ICommandHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public string HandleCommand(ICommand command, IEngine engine)
        {
            string result;
            if (this.CanHandle(command))
            {
                result = this.Handle(command, engine);
            }
            else if (this.nextHandler != null)
            {
                result = this.nextHandler.HandleCommand(command, engine);
            }
            else
            {
                result = string.Format(InvalidCommand, command.Name);
            }

            return result;
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command, IEngine engine);
    }
}
