using System;

using MatrixPath.Logic.UI.Contracts;

namespace MatrixPath.Logic.UI
{
    public class BasicUserInterface : IUserInterface
    {
        private Action<string> write;
        private Func<string> read;

        public BasicUserInterface(Action<string> writeMethod, Func<string> readMethod)
        {
            if (writeMethod == null)
            {
                throw new ArgumentNullException(nameof(writeMethod));
            }

            if (readMethod == null)
            {
                throw new ArgumentNullException(nameof(readMethod));
            }

            this.write = writeMethod;
            this.read = readMethod;
        }

        public string AskForInput(string message = "Waiting for input...")
        {
            this.write(message);
            var input = this.read();

            return input;
        }

        public void PostMessage(string message)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            this.write(message);
        }
    }
}
