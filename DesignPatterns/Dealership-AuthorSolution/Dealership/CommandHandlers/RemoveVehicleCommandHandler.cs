using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Data.Services.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class RemoveVehicleCommandHandler : BaseCommandHandler
    {
        private const string RemoveVehicleCommandName = "RemoveVehicle";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";

        public RemoveVehicleCommandHandler(IUserService userService)
            : base(userService)
        {
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == RemoveVehicleCommandHandler.RemoveVehicleCommandName;
        }

        protected override string Handle(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            base.ValidateRange(vehicleIndex, 0, base.UserService.LoggedUser.Vehicles.Count, RemoveVehicleCommandHandler.RemovedVehicleDoesNotExist);

            base.UserService.RemoveUserVehicle(vehicleIndex);

            return string.Format(RemoveVehicleCommandHandler.VehicleRemovedSuccessfully, base.UserService.LoggedUser.Username);
        }
    }
}
