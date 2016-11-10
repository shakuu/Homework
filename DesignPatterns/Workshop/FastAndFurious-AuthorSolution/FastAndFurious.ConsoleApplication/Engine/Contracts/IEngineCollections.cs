using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IEngineCollections
    {
        ICollection<IDriver> Drivers { get; }

        ICollection<IRaceTrack> RaceTracks { get; }

        ICollection<ITunningPart> TunningParts { get; }

        ICollection<IMotorVehicle> MotorVehicles { get; }

        IInputOutputProvider IoProvider { get; }

    }
}
