using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class RemovalStrategy : Strategy
    {
        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.RemovalStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var removeTypeCommand = commandParameters[1];
            var objectToRemoveId = int.Parse(commandParameters[2]);
            var ownerToRemoveFromId = int.Parse(commandParameters[5]);

            switch (removeTypeCommand)
            {
                case GlobalConstants.DriverCommand:
                    {
                        var raceTrackToRemoveFrom = engineCollections.RaceTracks.GetById(ownerToRemoveFromId);
                        var driverToRemove = raceTrackToRemoveFrom.Participants.GetById(objectToRemoveId);
                        raceTrackToRemoveFrom.RemoveParticipant(driverToRemove);
                        break;
                    }
                case GlobalConstants.TunningCommand:
                    {
                        var vehicleToRemoveFrom = engineCollections.MotorVehicles.GetById(ownerToRemoveFromId);
                        var tunningPartToRemove = vehicleToRemoveFrom.TunningParts.GetById(objectToRemoveId);
                        vehicleToRemoveFrom.RemoveTunning(tunningPartToRemove);
                        break;
                    }
                case GlobalConstants.VehicleCommand:
                    {
                        var driverToRemoveFrom = engineCollections.Drivers.GetById(ownerToRemoveFromId);
                        var vehicleToRemove = driverToRemoveFrom.Vehicles.GetById(objectToRemoveId);
                        driverToRemoveFrom.RemoveVehicle(vehicleToRemove);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(GlobalConstants.RemovalOperationNotSupportedExceptionMessage);
                    }
            }
        }
    }
}
