using Dealership.CommandHandlers.Base;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LoggedUserCommandHandler : BaseCommandHandler
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IUserService userService;

        public LoggedUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name != "RegisterUser" && command.Name != "Login" && !this.userService.HasLoggedUser;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            return UserNotLogged;
        }
    }
}
