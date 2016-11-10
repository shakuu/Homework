using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Exceptions;
using FastAndFurious.ConsoleApplication.Common.Extensions;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public class Engine : IEngine, IEngineCollections
    {
        private readonly ICollection<IDriver> drivers;
        private readonly ICollection<IRaceTrack> raceTracks;
        private readonly ICollection<ITunningPart> tunningParts;
        private readonly ICollection<IMotorVehicle> motorVehicles;

        private readonly IInputOutputProvider ioProvider;
        private readonly IStrategy commandExecutionStrategy;

        public Engine(IStrategy commandExecutionStrategy, IInputOutputProvider ioProiver)
        {
            if (commandExecutionStrategy == null)
            {
                throw new ArgumentNullException(nameof(commandExecutionStrategy));
            }

            if (ioProiver == null)
            {
                throw new ArgumentNullException(nameof(ioProiver));
            }

            this.commandExecutionStrategy = commandExecutionStrategy;
            this.ioProvider = ioProiver;

            this.drivers = new List<IDriver>();
            this.raceTracks = new List<IRaceTrack>();
            this.tunningParts = new List<ITunningPart>();
            this.motorVehicles = new List<IMotorVehicle>();
        }

        public ICollection<IDriver> Drivers
        {
            get
            {
                return this.drivers;
            }
        }

        public ICollection<IRaceTrack> RaceTracks
        {
            get
            {
                return this.raceTracks;
            }
        }

        public ICollection<ITunningPart> TunningParts
        {
            get
            {
                return this.tunningParts;
            }
        }

        public ICollection<IMotorVehicle> MotorVehicles
        {
            get
            {
                return this.motorVehicles;
            }
        }

        public IInputOutputProvider IoProvider
        {
            get
            {
                return this.ioProvider;
            }
        }

        public void Start()
        {
            var command = this.ReadCommand();
            var commandParameters = new string[] { string.Empty };

            while (command != GlobalConstants.ExitCommand)
            {
                commandParameters = ParseCommand(command);
                try
                {
                    ExecuteCommand(commandParameters);
                }
                catch (NotSupportedException e)
                {
                    this.ioProvider.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.ioProvider.WriteLine(e.Message);
                }
                catch (TunningDuplicationException e)
                {
                    this.ioProvider.WriteLine(e.Message);
                }

                command = this.ReadCommand();
            }
        }

        private string ReadCommand()
        {
            return this.ioProvider.ReadLine();
        }

        private string[] ParseCommand(string command)
        {
            return command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void ExecuteCommand(string[] commandParameters)
        {
            this.commandExecutionStrategy.Execute(commandParameters, this);

            // Choose strategy
            //var commandType = commandParameters[0];
            //switch (commandType)
            //{
            //    case GlobalConstants.CreationStrategyCommand:
            //        this.ExecuteCreationStrategy(commandParameters);
            //        break;
            //    case GlobalConstants.RemovalStrategyCommand:
            //        this.ExecuteRemovalStrategy(commandParameters);
            //        break;
            //    case GlobalConstants.AssigningStrategyCommand:
            //        this.ExecuteAssigningStrategy(commandParameters);
            //        break;
            //    case GlobalConstants.SelectingStrategyCommand:
            //        this.ExecuteSelectingStrategy(commandParameters);
            //        break;
            //    case GlobalConstants.RunningStrategyCommand:
            //        this.ExecuteRunningStrategy(commandParameters);
            //        break;
            //    case GlobalConstants.DisplayingStrategyCommand:
            //        this.ExecuteDisplayingStrategy(commandParameters);
            //        break;
            //    default:
            //        throw new InvalidOperationException();
            //}
        }

        private void ExecuteCreationStrategy(string[] commandParameters)
        {
            var createTypeCommand = commandParameters[1];
            var typeName = commandParameters[2];

            switch (createTypeCommand)
            {
                case GlobalConstants.DriverCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.drivers);
                    break;
                case GlobalConstants.TrackCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.raceTracks);
                    break;
                case GlobalConstants.TunningCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.tunningParts);
                    break;
                case GlobalConstants.VehicleCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.motorVehicles);
                    break;
                default:
                    throw new NotSupportedException(GlobalConstants.CreationalOperationNotSupportedExceptionMessage);
            }

            this.ioProvider.WriteLine(String.Format("{0} - successfully created!", typeName));
        }

        private void ExecuteAssigningStrategy(string[] commandParameters)
        {
            var removeTypeCommand = commandParameters[1];
            var objectToAssignId = int.Parse(commandParameters[2]);
            var ownerToAssignToId = int.Parse(commandParameters[5]);

            switch (removeTypeCommand)
            {
                case GlobalConstants.TunningCommand:
                    {
                        var vehicleToAssignTo = this.motorVehicles.GetById(ownerToAssignToId);
                        var tunningToAssign = this.tunningParts.GetById(objectToAssignId);
                        vehicleToAssignTo.AddTunning(tunningToAssign);
                        break;
                    }
                case GlobalConstants.VehicleCommand:
                    {
                        var driverToAssignTo = this.drivers.GetById(ownerToAssignToId);
                        var vehicleToAssign = this.motorVehicles.GetById(objectToAssignId);
                        driverToAssignTo.AddVehicle(vehicleToAssign);
                        break;
                    }
                case GlobalConstants.DriverCommand:
                    {
                        var raceTrackToAssignTo = this.raceTracks.GetById(ownerToAssignToId);
                        var driverToAssign = this.drivers.GetById(objectToAssignId);
                        raceTrackToAssignTo.AddParticipant(driverToAssign);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(GlobalConstants.AssigningOperationNotSupportedExceptionMessage);
                    }
            }

            this.ioProvider.WriteLine(
                String.Format(
                    GlobalConstants.ItemAssignedSuccessfullyMessage,
                    objectToAssignId,
                    ownerToAssignToId));
        }

        private void ExecuteRemovalStrategy(string[] commandParameters)
        {
            var removeTypeCommand = commandParameters[1];
            var objectToRemoveId = int.Parse(commandParameters[2]);
            var ownerToRemoveFromId = int.Parse(commandParameters[5]);

            switch (removeTypeCommand)
            {
                case GlobalConstants.DriverCommand:
                    {
                        var raceTrackToRemoveFrom = this.raceTracks.GetById(ownerToRemoveFromId);
                        var driverToRemove = raceTrackToRemoveFrom.Participants.GetById(objectToRemoveId);
                        raceTrackToRemoveFrom.RemoveParticipant(driverToRemove);
                        break;
                    }
                case GlobalConstants.TunningCommand:
                    {
                        var vehicleToRemoveFrom = this.motorVehicles.GetById(ownerToRemoveFromId);
                        var tunningPartToRemove = vehicleToRemoveFrom.TunningParts.GetById(objectToRemoveId);
                        vehicleToRemoveFrom.RemoveTunning(tunningPartToRemove);
                        break;
                    }
                case GlobalConstants.VehicleCommand:
                    {
                        var driverToRemoveFrom = this.drivers.GetById(ownerToRemoveFromId);
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

        private void ExecuteSelectingStrategy(string[] commandParameters)
        {
            var driverId = int.Parse(commandParameters[5]);
            var driver = this.drivers.GetById(driverId);
            var vehicleId = int.Parse(commandParameters[2]);
            var vehicle = driver.Vehicles.GetById(vehicleId);
            driver.SetActiveVehicle(vehicle);

            this.ioProvider.WriteLine(
                String.Format(
                    GlobalConstants.DriverSelectsNewVehicleMessage,
                    driver.Name,
                    driver.Gender == GenderType.Male ? "his" : "her",
                    vehicle.GetType().Name));
        }

        private void ExecuteRunningStrategy(string[] commandParameters)
        {
            var trackId = int.Parse(commandParameters[2]);
            var track = this.raceTracks.GetById(trackId);
            this.ioProvider.WriteLine(String.Format(GlobalConstants.PerformingRaceOnTrackMessage, track.TrackName, track.Participants.Count()));
            track.RunRace();
        }

        private void ExecuteDisplayingStrategy(string[] commandParameters)
        {
            var count = int.Parse(commandParameters[2]);
            var raceTrackId = int.Parse(commandParameters[6]);
            var raceTrack = this.raceTracks.GetById(raceTrackId);
            var results = raceTrack.FinishedRacesResults
                .SelectMany(x => x)
                .OrderBy(x => x.TotalSeconds)
                .Take(count);

            this.ioProvider.WriteLine(
                results != null && results.Count() > 0 ?
                String.Format(GlobalConstants.DisplayBestNTimesEverMessage, count, raceTrack.TrackName) :
                String.Format(GlobalConstants.NoRacesYetMessage, raceTrack.TrackName));

            foreach (var result in results)
            {
                this.ioProvider.WriteLine(result.ToString());
            }
        }

        private void CreateObjectOfTypeAndAssignToCollection<T>(string typeName, ICollection<T> collection)
        {
            var typeToInstantiate = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeName);
            var instanceOfType = (T)Activator.CreateInstance(typeToInstantiate);
            collection.Add(instanceOfType);
        }
    }
}
