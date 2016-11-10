using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Commands
{
    public class VehicleCommand : AssigningCommand
    {
        public override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var ownerToAssignToId = base.GetOwnerToAssignToId(commandParameters);
            var objectToAssignId = base.GetObjectToAssignId(commandParameters);

            var driverToAssignTo = engineCollections.Drivers.GetById(ownerToAssignToId);
            var vehicleToAssign = engineCollections.MotorVehicles.GetById(objectToAssignId);
            driverToAssignTo.AddVehicle(vehicleToAssign);
        }

        public override bool IsCommand(IList<string> commandParameters)
        {
            return GlobalConstants.VehicleCommand == commandParameters[1];
        }
    }
}
