using Dealership.Engine;

namespace Dealership.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string input);
    }
}
