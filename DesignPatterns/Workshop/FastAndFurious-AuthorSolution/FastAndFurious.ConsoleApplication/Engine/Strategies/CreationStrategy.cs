using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class CreationStrategy : Strategy
    {
        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.CreationStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var createTypeCommand = commandParameters[1];
            var typeName = commandParameters[2];

            switch (createTypeCommand)
            {
                case GlobalConstants.DriverCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, engineCollections.Drivers);
                    break;
                case GlobalConstants.TrackCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, engineCollections.RaceTracks);
                    break;
                case GlobalConstants.TunningCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, engineCollections.TunningParts);
                    break;
                case GlobalConstants.VehicleCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, engineCollections.MotorVehicles);
                    break;
                default:
                    throw new NotSupportedException(GlobalConstants.CreationalOperationNotSupportedExceptionMessage);
            }

            engineCollections.IoProvider.WriteLine(String.Format("{0} - successfully created!", typeName));
        }

        private void CreateObjectOfTypeAndAssignToCollection<T>(string typeName, ICollection<T> collection)
        {
            var typeToInstantiate = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeName);
            var instanceOfType = (T)Activator.CreateInstance(typeToInstantiate);
            collection.Add(instanceOfType);
        }
    }
}
