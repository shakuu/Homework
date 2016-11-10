using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class SelectingStrategy : Strategy
    {
        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.SelectingStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var driverId = int.Parse(commandParameters[5]);
            var driver = engineCollections.Drivers.GetById(driverId);
            var vehicleId = int.Parse(commandParameters[2]);
            var vehicle = driver.Vehicles.GetById(vehicleId);
            driver.SetActiveVehicle(vehicle);

            engineCollections.IoProvider.WriteLine(
                String.Format(
                    GlobalConstants.DriverSelectsNewVehicleMessage,
                    driver.Name,
                    driver.Gender == GenderType.Male ? "his" : "her",
                    vehicle.GetType().Name));
        }
    }
}
