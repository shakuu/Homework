namespace ConsoleWebServer.Framework
{
    public interface IHttpRequestManager
    {
        HttpRequestManager Parse(string reqAsStr);
    }
}