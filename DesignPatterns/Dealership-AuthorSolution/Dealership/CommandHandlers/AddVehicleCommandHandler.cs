using System;

using Dealership.CommandHandlers.Base;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;

namespace Dealership.CommandHandlers
{
    public class AddVehicleCommandHandler : BaseCommandHandler
    {
        private const string AddVehicleCommandName = "AddVehicle";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private readonly IDealershipFactory factory;

        public AddVehicleCommandHandler(IDealershipFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == AddVehicleCommandHandler.AddVehicleCommandName;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            IVehicle vehicle = null;

            if (typeEnum == VehicleType.Car)
            {
                vehicle = this.factory.GetCar(make, model, price, int.Parse(additionalParam));
            }
            else if (typeEnum == VehicleType.Motorcycle)
            {
                vehicle = this.factory.GetMotorcycle(make, model, price, additionalParam);
            }
            else if (typeEnum == VehicleType.Truck)
            {
                vehicle = this.factory.GetTruck(make, model, price, int.Parse(additionalParam));
            }

            engine.LoggedUser.AddVehicle(vehicle);

            return string.Format(VehicleAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
