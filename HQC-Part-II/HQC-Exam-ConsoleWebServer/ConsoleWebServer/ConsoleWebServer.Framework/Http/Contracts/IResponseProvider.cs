namespace ConsoleWebServer.Framework.Http.Contracts
{
    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    }
}




