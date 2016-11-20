using Dealership.Data.Contracts;

namespace Dealership.Data.Services.Contracts
{
    public interface IUserService
    {
        bool HasLoggedUser { get; set; }

        void SetLoggedUser(IUser user);

        IUser CreateUser(string username, string firstName, string lastName, string password, string role);
    }
}
