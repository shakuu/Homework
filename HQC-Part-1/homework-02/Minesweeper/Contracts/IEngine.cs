namespace Minesweeper.Contracts
{
    /// <summary>
    /// Parse and execute string commands.
    /// </summary>
    public interface IEngine
    {
        bool ExecuteNextCommand(string command);
    }
}
