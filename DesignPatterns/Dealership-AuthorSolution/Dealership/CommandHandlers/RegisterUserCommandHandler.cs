using System;

using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class RegisterUserCommandHandler : BaseCommandHandler
    {
        private const string CanHandleCommandName = "RegisterUser";

        public RegisterUserCommandHandler(ICommandHandler nextHandler) 
            : base(nextHandler)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            throw new NotImplementedException();
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            throw new NotImplementedException();
        }
    }
}
