using System.Collections.Generic;

using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;

namespace Dealership.CommandHandlers.Contracts
{
    public interface ICommandHandler
    {
        string HandleCommand(ICommand command, ICollection<IUser> users, IDealershipFactory factory );
    }
}
