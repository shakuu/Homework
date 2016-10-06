using System.Collections.Generic;
using ConsoleWebServer.Framework.Contracts;

public class JsonActionResultWithCors : JsonActionResult
{
    public JsonActionResultWithCors(IHttpRequestManager requestManager, object model, string corsSettings)
        : base(requestManager, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    }
}