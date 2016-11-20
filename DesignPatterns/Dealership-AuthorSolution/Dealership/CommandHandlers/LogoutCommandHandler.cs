using Dealership.CommandHandlers.Base;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LogoutCommandHandler : BaseCommandHandler
    {
        private const string LogoutCommandName = "Logout";
        private const string UserLoggedOut = "You logged out!";

        public LogoutCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == LogoutCommandHandler.LogoutCommandName;
        }

        protected override string Handle(ICommand command)
        {
            base.UserService.SetLoggedUser(null);
            return LogoutCommandHandler.UserLoggedOut;
        }
    }
}
