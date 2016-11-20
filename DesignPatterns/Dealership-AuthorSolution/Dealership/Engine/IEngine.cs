using System.Collections.Generic;

using Dealership.Contracts;

namespace Dealership.Engine
{
    public interface IEngine
    {
        ICollection<IUser> Users { get; }

        IUser LoggedUser { get; }

        void SetLoggedUser(IUser user);

        void Start();
    }
}
