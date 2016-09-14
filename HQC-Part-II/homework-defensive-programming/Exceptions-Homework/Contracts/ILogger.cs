using System.Collections.Generic;

namespace Exceptions_Homework.Contracts
{
    public interface ILogger
    {
        IEnumerable<string> Messages { get; }

        void Log(string message);
    }
}
