using ConsoleWebServer.Framework.Http;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionResult
    {
        IHttpResponse GetResponse();
    }
}