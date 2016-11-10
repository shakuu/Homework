using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Commands
{
    public class DriverCommand : AssigningCommand
    {
        public override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var ownerToAssignToId = base.GetOwnerToAssignToId(commandParameters);
            var objectToAssignId = base.GetObjectToAssignId(commandParameters);

            var raceTrackToAssignTo = engineCollections.RaceTracks.GetById(ownerToAssignToId);
            var driverToAssign = engineCollections.Drivers.GetById(objectToAssignId);
            raceTrackToAssignTo.AddParticipant(driverToAssign);
        }

        public override bool IsCommand(IList<string> commandParameters)
        {
            return GlobalConstants.DriverCommand == commandParameters[1];
        }
    }
}
