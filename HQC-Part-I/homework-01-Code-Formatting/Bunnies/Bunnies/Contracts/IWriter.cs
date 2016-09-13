namespace Bunnies.Contracts
{
    /// <summary>
    /// Provides functionality for writing strings.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Writes a string without a new line at the end.
        /// </summary>
        /// <param name="message"> The string to write. </param>
        void Write(string message);

        /// <summary>
        /// Writes a string and appends a new line at the end.
        /// </summary>
        /// <param name="message"> The string to write. </param>
        void WriteLine(string message);
    }
}
