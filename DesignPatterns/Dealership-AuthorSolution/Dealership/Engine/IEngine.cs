using System.Collections.Generic;

using Dealership.Contracts;

namespace Dealership.Engine
{
    public interface IEngine
    {
        void Start();

        void Reset();

        ICollection<IUser> Users { get; }

        bool HasLoggedUser { get; }
    }
}
