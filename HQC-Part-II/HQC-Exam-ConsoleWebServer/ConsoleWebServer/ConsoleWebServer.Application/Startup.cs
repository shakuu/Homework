// TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt
namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main(int a)
        {
            var webSever = new WebServerConsole5();
            webSever.Start();
        }
    }
}
