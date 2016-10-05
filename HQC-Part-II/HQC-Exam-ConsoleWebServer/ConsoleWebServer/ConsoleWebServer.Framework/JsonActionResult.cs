using System;
using System.Collections.Generic;using System.Text;
using System.Net;
using ConsoleWebServer.Framework;
using Newtonsoft.Json;

public class JsonActionResult : IActionResult {
    public virtual HttpStatusCode GetStatusCode() {
        return HttpStatusCode.OK;
    }
    public JsonActionResult(HttpRequestManager requestManager, object m)
    {
        model = m;
        this.RequestManager = requestManager;
        ResponseHeaders = new List<KeyValuePair<string, string>>();
    }
    public HttpRequestManager RequestManager { get; private set; }
    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }
    public string GetContent() {
        return JsonConvert.SerializeObject(model);
    }
    public readonly object model;
    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(this.RequestManager.ProtocolVersion, GetStatusCode(), GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
        foreach (var responseHeader in ResponseHeaders)
        {
            response.AddHeader(responseHeader.Key, responseHeader.Value);
        }
        return response;
    }
}
public class JsonActionResultWithCors : JsonActionResult{
    public JsonActionResultWithCors(HttpRequestManager requestManager, object model, string corsSettings)
        : base(requestManager, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}
public class JsonActionResultWithoutCaching : JsonActionResult{
    public JsonActionResultWithoutCaching(HttpRequestManager r, object model)
        : base(r, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        throw new Exception();
    }
}
public class JsonActionResultWithCorsWithoutCaching : JsonActionResult{
    public JsonActionResultWithCorsWithoutCaching(HttpRequestManager requestManager, object model, string corsSettings)
        : base(requestManager, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}