using System.Collections.Generic;

using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public interface IEngine
    {
        IDealershipFactory Factory { get; }

        ICollection<IUser> Users { get; }

        IUser LoggedUser { get; }

        void SetLoggedUser(IUser user);

        void Start();

        void Reset();
    }
}
