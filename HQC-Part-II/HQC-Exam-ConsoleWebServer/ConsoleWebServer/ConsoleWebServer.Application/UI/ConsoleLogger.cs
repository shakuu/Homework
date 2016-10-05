using System;

namespace ConsoleWebServer.Application.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(object message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
