// TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt

using ConsoleWebServer.Application.Loggers;
using ConsoleWebServer.Application.UI;
using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Http;
using ConsoleWebServer.Framework.Http.Factory;

namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            var webSever = CreateWebServer();
            webSever.Start();
        }

        private static WebServerConsole CreateWebServer()
        {
            var requestManager = new HttpRequestManager();

            var logger = new ConsoleLogger();
            var inputProvider = new ConsoleInputProvider();
            var actionInvoker = new ActionInvoker();
            var responseProvider = new ResponseProvider(
                requestManager,
                actionInvoker,
                HttpResponseFactory.CreateHttpResponse);

            var webServer = new WebServerConsole(responseProvider, inputProvider, logger);
            return webServer;
        }
    }
}
