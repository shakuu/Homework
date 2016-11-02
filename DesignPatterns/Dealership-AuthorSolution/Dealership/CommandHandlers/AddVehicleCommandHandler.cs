using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dealership.CommandHandlers.Base;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.CommandHandlers
{
    public class AddVehicleCommandHandler : BaseCommandHandler
    {
        private const string AddVehicleCommandName = "AddVehicle";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        public AddVehicleCommandHandler(ICommandHandler nextHandler)
            : base(nextHandler)
        {
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
                vehicle = engine.Factory.CreateCar(make, model, price, int.Parse(additionalParam));
            }
            else if (typeEnum == VehicleType.Motorcycle)
            {
                vehicle = engine.Factory.CreateMotorcycle(make, model, price, additionalParam);
            }
            else if (typeEnum == VehicleType.Truck)
            {
                vehicle = engine.Factory.CreateTruck(make, model, price, int.Parse(additionalParam));
            }

            engine.LoggedUser.AddVehicle(vehicle);

            return string.Format(VehicleAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
