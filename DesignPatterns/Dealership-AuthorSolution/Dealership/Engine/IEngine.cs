using System.Collections.Generic;

using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public interface IEngine
    {
        void Start();

        void Reset();

        IDealershipFactory Factory { get; }

        ICollection<IUser> Users { get; }

        IUser LoggedUser { get; set; }
    }
}
