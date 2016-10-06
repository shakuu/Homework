namespace ConsoleWebServer.Framework.Contracts
{
    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    }
}




