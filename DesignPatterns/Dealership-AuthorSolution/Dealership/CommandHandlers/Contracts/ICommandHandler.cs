using Dealership.Engine;

namespace Dealership.CommandHandlers.Contracts
{
    public interface ICommandHandler
    {
        string HandleCommand(ICommand command, IEngine engine);
    }
}
