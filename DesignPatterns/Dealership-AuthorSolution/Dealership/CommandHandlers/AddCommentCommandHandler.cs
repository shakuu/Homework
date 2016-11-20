using Dealership.CommandHandlers.Base;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class AddCommentCommandHandler : BaseCommandHandler
    {
        private const string AddCommentCommandName = "AddComment";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        public AddCommentCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == AddCommentCommandHandler.AddCommentCommandName;
        }

        protected override string Handle(ICommand command)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            base.UserService.AddUserComment(content, vehicleIndex);

            return string.Format(AddCommentCommandHandler.CommentAddedSuccessfully, base.UserService.LoggedUser.Username);
        }
    }
}
