using Dealership.CommandHandlers.Base;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LogoutCommandHandler : BaseCommandHandler
    {
        private const string LogoutCommandName = "Logout";
        private const string UserLoggedOut = "You logged out!";
        
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == LogoutCommandHandler.LogoutCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            engine.SetLoggedUser(null);
            return LogoutCommandHandler.UserLoggedOut;
        }
    }
}
