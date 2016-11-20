using System.Collections.Generic;

using Dealership.Data.Common.Enums;
using Dealership.Data.Contracts;

namespace Dealership.Data.Services.Contracts
{
    public interface IUserService
    {
        IUser LoggedUser { get; }

        void SetLoggedUser(IUser user);

        IUser CreateUser(string username, string firstName, string lastName, string password, string role);

        IEnumerable<IUser> FindAll();

        IUser FindByName(string name);

        void RemoveUserComment(int vehicleIndex, int commentIndex);

        void RemoveUserVehicle(int vehicleIndex);

        void AddUserComment(string content, int vehicleIndex);

        void AddUserVehicle(string make, string model, decimal price, string additional, VehicleType type);
    }
}
