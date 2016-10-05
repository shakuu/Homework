using System;

namespace ConsoleWebServer.Application.UI
{
  public  class ConsoleInputProvider : IInputProvider
  {
        public string ReadLine()
        {
            var line = Console.ReadLine();
            return line;
        }
    }
}
