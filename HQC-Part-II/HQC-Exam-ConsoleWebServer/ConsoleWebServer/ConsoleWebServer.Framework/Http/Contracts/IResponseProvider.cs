namespace ConsoleWebServer.Framework.Http.Contracts
{
    public interface IResponseProvider
    {
        IHttpResponse GetResponse(string requestAsString);
    }
}




