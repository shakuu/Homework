namespace Minesweeper.Contracts
{
    /// <summary>
    /// Exposes next game cycle method and IsRunning parameter.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Return True while the game engine is running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Prepare a new game.
        /// </summary>
        void StartNewGame();

        /// <summary>
        /// Execute next User command.
        /// </summary>
        void ExecuteNextGameCycle();
    }
}
