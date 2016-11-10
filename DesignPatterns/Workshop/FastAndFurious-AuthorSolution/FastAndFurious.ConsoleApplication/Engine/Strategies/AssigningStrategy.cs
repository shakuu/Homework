using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class AssigningStrategy : Strategy
    {
        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.AssigningStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var removeTypeCommand = commandParameters[1];
            var objectToAssignId = int.Parse(commandParameters[2]);
            var ownerToAssignToId = int.Parse(commandParameters[5]);

            switch (removeTypeCommand)
            {
                case GlobalConstants.TunningCommand:
                    {
                        var vehicleToAssignTo = engineCollections.MotorVehicles.GetById(ownerToAssignToId);
                        var tunningToAssign = engineCollections.TunningParts.GetById(objectToAssignId);
                        vehicleToAssignTo.AddTunning(tunningToAssign);
                        break;
                    }
                case GlobalConstants.VehicleCommand:
                    {
                        var driverToAssignTo = engineCollections.Drivers.GetById(ownerToAssignToId);
                        var vehicleToAssign = engineCollections.MotorVehicles.GetById(objectToAssignId);
                        driverToAssignTo.AddVehicle(vehicleToAssign);
                        break;
                    }
                case GlobalConstants.DriverCommand:
                    {
                        var raceTrackToAssignTo = engineCollections.RaceTracks.GetById(ownerToAssignToId);
                        var driverToAssign = engineCollections.Drivers.GetById(objectToAssignId);
                        raceTrackToAssignTo.AddParticipant(driverToAssign);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(GlobalConstants.AssigningOperationNotSupportedExceptionMessage);
                    }
            }

            engineCollections.IoProvider.WriteLine(
                String.Format(
                    GlobalConstants.ItemAssignedSuccessfullyMessage,
                    objectToAssignId,
                    ownerToAssignToId));
        }
    }
}
