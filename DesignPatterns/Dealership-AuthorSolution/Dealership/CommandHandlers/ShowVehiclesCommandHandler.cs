using Dealership.CommandHandlers.Base;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class ShowVehiclesCommandHandler : BaseCommandHandler
    {
        private const string ShowVehiclesCommandName = "ShowVehicles";
        private const string NoSuchUser = "There is no user with username {0}!";

        public ShowVehiclesCommandHandler(IUserService userService) 
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == ShowVehiclesCommandHandler.ShowVehiclesCommandName;
        }

        protected override string Handle(ICommand command)
        {
            var username = command.Parameters[0];

            var user = base.UserService.FindByName(username);

            if (user == null)
            {
                return string.Format(ShowVehiclesCommandHandler.NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
