using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Data.Services.Contracts;

namespace Dealership.CommandHandlers
{
    public class LoginCommandHandler : BaseCommandHandler
    {
        private const string LoginUserCommandName = "Login";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";

        public LoginCommandHandler(IUserService userService)
            : base(userService)
        {

        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == LoginCommandHandler.LoginUserCommandName;
        }

        protected override string Handle(ICommand command)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            if (base.UserService.LoggedUser != null)
            {
                return string.Format(LoginCommandHandler.UserLoggedInAlready, base.UserService.LoggedUser.Username);
            }

            var userFound = base.UserService.FindByName(username);

            if (userFound != null && userFound.Password == password)
            {
                base.UserService.SetLoggedUser(userFound);
                return string.Format(LoginCommandHandler.UserLoggedIn, username);
            }

            return LoginCommandHandler.WrongUsernameOrPassword;
        }
    }
}
