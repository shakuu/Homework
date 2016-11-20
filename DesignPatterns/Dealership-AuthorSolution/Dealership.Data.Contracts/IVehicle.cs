using Dealership.Data.Common.Enums;

namespace Dealership.Data.Contracts
{
    public interface IVehicle : ICommentable, IPriceable
    {
        int Wheels { get; }

        VehicleType Type { get; }

        string Make { get; }

        string Model { get;  }
    }
}
