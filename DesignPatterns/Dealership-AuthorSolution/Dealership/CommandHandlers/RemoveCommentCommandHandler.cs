using Dealership.CommandHandlers.Base;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class RemoveCommentCommandHandler : BaseCommandHandler
    {
        private const string RemoveCommentCommandName = "RemoveComment";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";

        public RemoveCommentCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == RemoveCommentCommandHandler.RemoveCommentCommandName;
        }

        protected override string Handle(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            var user = base.UserService.FindByName(username);

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, RemovedVehicleDoesNotExist);
            ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, RemovedCommentDoesNotExist);

            base.UserService.RemoveUserComment(vehicleIndex, commentIndex);

            return string.Format(CommentRemovedSuccessfully, base.UserService.LoggedUser.Username);
        }
    }
}
