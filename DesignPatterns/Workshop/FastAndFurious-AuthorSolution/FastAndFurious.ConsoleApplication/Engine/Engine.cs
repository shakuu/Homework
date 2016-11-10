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
                    this.commandExecutionStrategy.Execute(commandParameters, this);
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
    }
}
