using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;

namespace Dealership.CommandHandlers
{
    public class RemoveVehicleCommandHandler : BaseCommandHandler
    {
        private const string RemoveVehicleCommandName = "RemoveVehicle";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == RemoveVehicleCommandHandler.RemoveVehicleCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            base.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, RemoveVehicleCommandHandler.RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];

            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(RemoveVehicleCommandHandler.VehicleRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
