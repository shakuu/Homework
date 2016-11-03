using Dealership.Contracts;
using Dealership.Engine;

namespace Dealership.Factories
{
    public interface IDealershipFactory
    {
        IUser CreateUser(string username, string firstName, string lastName, string password, string role);

        IComment CreateComment(string content);

        ICommand CreateCommand(string input);

        IVehicle GetCar(string make, string model, decimal price, int seats);

        IVehicle GetMotorcycle(string make, string model, decimal price, string category);

        IVehicle GetTruck(string make, string model, decimal price, int weightCapacity);
    }
}
