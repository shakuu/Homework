using System.Text;

using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Common.Enums;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class ShowUsersCommandHandler : BaseCommandHandler
    {
        private const string ShowUsersCommandName = "ShowUsers";
        private const string YouAreNotAnAdmin = "You are not an admin!";
        
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == ShowUsersCommandHandler.ShowUsersCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            if (engine.LoggedUser.Role != Role.Admin)
            {
                return ShowUsersCommandHandler.YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in engine.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
