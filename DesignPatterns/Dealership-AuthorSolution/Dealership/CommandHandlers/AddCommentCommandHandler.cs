﻿using System;
using System.Linq;

using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Factories;

namespace Dealership.CommandHandlers
{
    public class AddCommentCommandHandler : BaseCommandHandler
    {
        private const string AddCommentCommandName = "AddComment";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        private readonly IDealershipFactory factory;

        public AddCommentCommandHandler(IDealershipFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == AddCommentCommandHandler.AddCommentCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = this.factory.CreateComment(content);
            comment.Author = engine.LoggedUser.Username;
            var user = engine.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(AddCommentCommandHandler.NoSuchUser, author);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, AddCommentCommandHandler.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            engine.LoggedUser.AddComment(comment, vehicle);

            return string.Format(AddCommentCommandHandler.CommentAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
