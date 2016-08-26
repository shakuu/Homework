namespace Minesweeper.Contracts
{
    public interface IGameEngine
    {
        bool IsRunning { get; }

        void ExecuteNextCommand(string command);
    }
}
