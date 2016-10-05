using System.Collections.Generic;using System.Text;
using System.Net;
using ConsoleWebServer.Framework;


public class ContentActionResult : IActionResult{
    public ContentActionResult(HttpRequest request, object model)
    {
        this.model = model;
        this.Request = request;
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
    public HttpRequest Request { get; private set; }
    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), "text/plain; charset=utf-8");
        foreach (var responseHeader in this.ResponseHeaders) { response.AddHeader(responseHeader.Key, responseHeader.Value); }
        return response;
    }
    public readonly object model;
    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }
}
public class ContentActionResultWithoutCaching : ContentActionResult {
    public ContentActionResultWithoutCaching(HttpRequest request, object model):base(request, model){
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
public class ContentActionResultWithCorsWithoutCaching : ContentActionResult {
    public ContentActionResultWithCorsWithoutCaching(HttpRequest request, object model, string corsSettings):base(request, model){
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
public class ContentActionResultWithCors<TResult> : ContentActionResult {
    public ContentActionResultWithCors(HttpRequest request, object model, string corsSettings): base(request, model){
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
