using System.Collections.Generic;using System.Text;
using System.Net;
using ConsoleWebServer.Framework;


public class ContentActionResult : IActionResult{
    public ContentActionResult(HttpRequestManager requestManager, object model)
    {
        this.model = model;
        this.RequestManager = requestManager;
            this
            .
            ResponseHeaders
            =
            new 
            List
            <
            KeyValuePair
            <
            string
            , 
            string
            >
            >
            (
            )
            ;
    }
    public HttpRequestManager RequestManager { get; private set; }
    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(this.RequestManager.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), "text/plain; charset=utf-8");
        foreach (var responseHeader in this.ResponseHeaders) { response.AddHeader(responseHeader.Key, responseHeader.Value); }
        return response;
    }
    public readonly object model;
    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }
}
public class ContentActionResultWithoutCaching : ContentActionResult {
    public ContentActionResultWithoutCaching(HttpRequestManager requestManager, object model):base(requestManager, model){
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
public class ContentActionResultWithCorsWithoutCaching : ContentActionResult {
    public ContentActionResultWithCorsWithoutCaching(HttpRequestManager requestManager, object model, string corsSettings):base(requestManager, model){
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
public class ContentActionResultWithCors<TResult> : ContentActionResult {
    public ContentActionResultWithCors(HttpRequestManager requestManager, object model, string corsSettings): base(requestManager, model){
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
