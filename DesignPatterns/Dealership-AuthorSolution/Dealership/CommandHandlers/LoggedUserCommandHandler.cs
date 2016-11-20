using Dealership.CommandHandlers.Base;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LoggedUserCommandHandler : BaseCommandHandler
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        public LoggedUserCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name != "RegisterUser" && command.Name != "Login" && base.UserService.LoggedUser != null;
        }

        protected override string Handle(ICommand command)
        {
            return UserNotLogged;
        }
    }
}
