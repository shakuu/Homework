namespace Events.Contracts
{
    /// <summary>
    /// Interface for Engine objects parsing string input commands and executing them.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Returns a string with the result of all executed operations.
        /// </summary>
        string Log { get; }

        /// <summary>
        /// Parses and executes the provided command string.
        /// </summary>
        /// <param name="command">Input command to parse and execute.</param>
        /// <returns>Returns False when End command is executed, returns True otherwise.</returns>
        bool ExecuteNextCommand(string command);
    }
}
