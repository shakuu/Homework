using System;

using Dealership.CommandHandlers.Base;
using Dealership.Data.Common.Enums;
using Dealership.Contracts;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;
using Dealership.Factories;

namespace Dealership.CommandHandlers
{
    public class AddVehicleCommandHandler : BaseCommandHandler
    {
        private const string AddVehicleCommandName = "AddVehicle";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private readonly IDealershipFactory factory;

        public AddVehicleCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == AddVehicleCommandHandler.AddVehicleCommandName;
        }

        protected override string Handle(ICommand command)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);
            
            base.UserService.AddVehicleToUser(make, model, price, additionalParam, typeEnum);

            return string.Format(VehicleAddedSuccessfully, base.UserService.LoggedUser.Username);
        }
    }
}
