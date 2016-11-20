using System;
using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Common.Enums;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class RegisterUserCommandHandler : BaseCommandHandler
    {
        private const string CanHandleCommandName = "RegisterUser";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserRegisterеd = "User {0} registered successfully!";

        public RegisterUserCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == RegisterUserCommandHandler.CanHandleCommandName;
        }

        protected override string Handle(ICommand command)
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

            if (base.UserService.LoggedUser != null)
            {
                return string.Format(RegisterUserCommandHandler.UserLoggedInAlready, base.UserService.LoggedUser.Username);
            }

            var foundUser = base.UserService.FindByName(username);
            if (foundUser != null)
            {
                return string.Format(RegisterUserCommandHandler.UserAlreadyExist, username);
            }

            var user = base.UserService.CreateUser(username, firstName, lastName, password, role.ToString());
            base.UserService.SetLoggedUser(user);

            return string.Format(RegisterUserCommandHandler.UserRegisterеd, username);
        }
    }
}
