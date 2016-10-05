// TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt

using ConsoleWebServer.Application.Loggers;
using ConsoleWebServer.Application.UI;
using ConsoleWebServer.Framework;

namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main(int a)
        {
            var webSever = CreateWebServer();
            webSever.Start();
        }

        private static WebServerConsole CreateWebServer()
        {
            var logger = new ConsoleLogger();
            var inputProvider = new ConsoleInputProvider();
            var responseProvider = new ResponseProvider();
            var webServer = new WebServerConsole(responseProvider, inputProvider, logger);
            return webServer;
        }
    }
}
