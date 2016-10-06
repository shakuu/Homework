namespace ConsoleWebServer.Framework.Contracts
{
    public interface IHttpRequestManager
    {
        IHttpRequest Parse(string reqAsStr);
    }
}