using System;

using Dealership.Common.Contracts;

namespace Dealership.Common
{
    public class GenericIOProvider : IIOProvider
    {
        private readonly Action<string> write;
        private readonly Func<string> readLine;

        public GenericIOProvider(Action<string> write, Func<string> readLine)
        {
            this.write = write;
            this.readLine = readLine;
        }

        public string ReadLine()
        {
            var input = this.readLine();
            return input;
        }

        public void WriteLine(string message)
        {
            this.write(message);
            this.write(Environment.NewLine);
        }

        public void Write(string message)
        {
            this.write(message);
        }
    }
}
