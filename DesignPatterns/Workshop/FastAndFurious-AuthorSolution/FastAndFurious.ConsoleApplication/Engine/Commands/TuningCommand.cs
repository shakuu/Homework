using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Commands
{
    public class TuningCommand : AssigningCommand
    {
        public override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var ownerToAssignToId = base.GetOwnerToAssignToId(commandParameters);
            var objectToAssignId = base.GetObjectToAssignId(commandParameters);

            var vehicleToAssignTo = engineCollections.MotorVehicles.GetById(ownerToAssignToId);
            var tunningToAssign = engineCollections.TunningParts.GetById(objectToAssignId);
            vehicleToAssignTo.AddTunning(tunningToAssign);
        }

        public override bool IsCommand(IList<string> commandParameters)
        {
            return GlobalConstants.TunningCommand == commandParameters[1];
        }
    }
}
