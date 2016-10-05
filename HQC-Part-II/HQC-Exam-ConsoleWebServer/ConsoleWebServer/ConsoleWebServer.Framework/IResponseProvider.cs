namespace ConsoleWebServer.Framework
{
    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    }
}




