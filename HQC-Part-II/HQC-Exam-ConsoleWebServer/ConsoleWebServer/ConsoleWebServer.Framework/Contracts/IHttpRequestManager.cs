namespace ConsoleWebServer.Framework.Contracts
{
    public interface IHttpRequestManager
    {
        HttpRequestManager Parse(string reqAsStr);
    }
}