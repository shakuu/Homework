namespace ConsoleWebServer.Framework.Http.Contracts
{
    public interface IHttpRequestManager
    {
        IHttpRequest Parse(string reqAsStr);
    }
}