namespace ConsoleWebServer.Framework.Http.Contracts
{
    public interface IHttpResponse
    {
        void AddHeader(string name, string value);
    }
}