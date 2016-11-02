using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class LoginCommandHandler : BaseCommandHandler
    {
        private const string LoginUserCommandName = "Login";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserLoggedIn = "User {0} successfully logged in!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";

        public LoginCommandHandler(ICommandHandler nextHandler)
            : base(nextHandler)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == LoginCommandHandler.LoginUserCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            if (engine.LoggedUser != null)
            {
                return string.Format(LoginCommandHandler.UserLoggedInAlready, engine.LoggedUser.Username);
            }

            var userFound = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound != null && userFound.Password == password)
            {
                engine.SetLoggedUser(userFound);
                return string.Format(LoginCommandHandler.UserLoggedIn, username);
            }

            return LoginCommandHandler.WrongUsernameOrPassword;
        }
    }
}
