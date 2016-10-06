using ConsoleWebServer.Framework.Http;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionResult
    {
        HttpResponse GetResponse();
    }
}