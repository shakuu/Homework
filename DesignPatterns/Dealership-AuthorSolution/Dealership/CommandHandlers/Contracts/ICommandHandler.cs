using Dealership.Engine;

namespace Dealership.CommandHandlers.Contracts
{
    public interface ICommandHandler
    {
        void AddCommandHandler(ICommandHandler loginHandler);

        string HandleCommand(ICommand command);
    }
}
