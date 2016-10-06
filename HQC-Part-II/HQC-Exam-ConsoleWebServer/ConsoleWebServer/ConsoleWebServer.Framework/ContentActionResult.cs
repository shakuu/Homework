using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Contracts;


public class ContentActionResult : IActionResult
{
    public ContentActionResult(IHttpRequest requestManager, object model)
    {
        this.model = model;
        this.RequestManager = requestManager;
        this.ResponseHeaders = new List<KeyValuePair<string, string>>();
    }

    public IHttpRequest RequestManager { get; private set; }

    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(this.RequestManager.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), "text/plain; charset=utf-8");
        foreach (var responseHeader in this.ResponseHeaders) { response.AddHeader(responseHeader.Key, responseHeader.Value); }
        return response;
    }

    public readonly object model;

    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }
}
public class ContentActionResultWithoutCaching : ContentActionResult
{
    public ContentActionResultWithoutCaching(IHttpRequest requestManager, object model) : base(requestManager, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
{
    public ContentActionResultWithCorsWithoutCaching(IHttpRequest requestManager, object model, string corsSettings) : base(requestManager, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
public class ContentActionResultWithCors<TResult> : ContentActionResult
{
    public ContentActionResultWithCors(IHttpRequest requestManager, object model, string corsSettings) : base(requestManager, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
