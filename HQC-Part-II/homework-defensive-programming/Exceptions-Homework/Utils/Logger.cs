using System;
using System.Collections.Generic;

using Exceptions_Homework.Contracts;

namespace Exceptions_Homework.Utils
{
    public class Logger : ILogger
    {
        ICollection<string> messages;

        public Logger()
        {
            this.messages = new LinkedList<string>();
        }

        public IEnumerable<string> Messages
        {
            get
            {
                var output = new List<string>(this.messages);
                return output;
            }
        }

        public void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message is null or empty");
            }

            this.messages.Add(message);
        }

        public override string ToString()
        {
            var concatinatedMessages = string.Join(Environment.NewLine, this.messages);
            return concatinatedMessages;
        }
    }
}
