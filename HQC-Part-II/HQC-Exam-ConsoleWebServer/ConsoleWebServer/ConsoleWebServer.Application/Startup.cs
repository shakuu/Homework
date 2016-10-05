﻿// TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt

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
            var responseProvider = new ResponseProvider();
            var webServer = new WebServerConsole(responseProvider);
            return webServer;
        }
    }
}
