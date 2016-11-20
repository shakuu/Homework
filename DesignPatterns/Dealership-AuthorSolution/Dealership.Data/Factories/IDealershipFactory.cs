﻿
using Dealership.Data.Contracts;

namespace Dealership.Data.Factories
{
    public interface IDealershipFactory
    {
        IUser CreateUser(string username, string firstName, string lastName, string password, string role);

        IComment CreateComment(string content);
        
        IVehicle GetCar(string make, string model, decimal price, int seats);

        IVehicle GetMotorcycle(string make, string model, decimal price, string category);

        IVehicle GetTruck(string make, string model, decimal price, int weightCapacity);
    }
}
