namespace Bunnies.Utils
{
    using System;

    using Bunnies.Contracts;

    /// <summary>
    /// Implements IWriter through the console.
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Writes a string without a new line at the end.
        /// </summary>
        /// <param name="message"> The string to write. </param>
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Writes a string and appends a new line at the end.
        /// </summary>
        /// <param name="message"> The string to write. </param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
