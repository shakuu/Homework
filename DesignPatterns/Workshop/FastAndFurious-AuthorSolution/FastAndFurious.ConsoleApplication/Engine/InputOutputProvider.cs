using System;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
