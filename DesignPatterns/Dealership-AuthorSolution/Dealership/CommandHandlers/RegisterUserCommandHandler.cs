using System;
using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;
using Dealership.Common.Enums;

namespace Dealership.CommandHandlers
{
    public class RegisterUserCommandHandler : BaseCommandHandler
    {
        private const string CanHandleCommandName = "RegisterUser";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserRegisterеd = "User {0} registered successfully!";

        public RegisterUserCommandHandler(ICommandHandler nextHandler)
            : base(nextHandler)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == RegisterUserCommandHandler.CanHandleCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];

            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            if (engine.LoggedUser != null)
            {
                return string.Format(RegisterUserCommandHandler.UserLoggedInAlready, engine.LoggedUser.Username);
            }

            if (engine.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                return string.Format(RegisterUserCommandHandler.UserAlreadyExist, username);
            }

            var user = engine.Factory.CreateUser(username, firstName, lastName, password, role.ToString());
            engine.SetLoggedUser(user);
            engine.Users.Add(user);

            return string.Format(RegisterUserCommandHandler.UserRegisterеd, username);
        }
    }
}
