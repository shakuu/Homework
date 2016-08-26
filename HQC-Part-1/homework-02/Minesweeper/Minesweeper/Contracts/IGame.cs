namespace Minesweeper.Contracts
{
    public interface IGameEngine
    {
        /// <summary>
        /// Return True while the game engine is running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Execute next User command.
        /// </summary>
        void ExecuteNextCommand();
    }
}
