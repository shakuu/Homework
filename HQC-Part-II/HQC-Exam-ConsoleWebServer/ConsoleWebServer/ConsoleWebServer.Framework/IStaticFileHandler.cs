using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework
{
    public interface IStaticFileHandler
    {
        bool CanHandle(IHttpRequest requestManager);
        IHttpResponse Handle(IHttpRequest requestManager);
    }
}