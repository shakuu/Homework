using System;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public class InterceptedInputOutputProvider : IInputOutputProvider
    {
        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}
