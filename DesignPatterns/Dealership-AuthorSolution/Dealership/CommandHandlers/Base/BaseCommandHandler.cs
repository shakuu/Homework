using System;

using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;
using Dealership.Data.Services.Contracts;

namespace Dealership.CommandHandlers.Base
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        private const string InvalidCommand = "Invalid command!";

        private readonly IUserService userService;

        private ICommandHandler nextHandler;

        public BaseCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected IUserService UserService
        {
            get
            {
                return this.userService;
            }
        }

        public void AddCommandHandler(ICommandHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public string HandleCommand(ICommand command)
        {
            string result;
            if (this.CanHandle(command))
            {
                result = this.Handle(command);
            }
            else if (this.nextHandler != null)
            {
                result = this.nextHandler.HandleCommand(command);
            }
            else
            {
                result = string.Format(InvalidCommand, command.Name);
            }

            return result;
        }

        protected void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string Handle(ICommand command);
    }
}
