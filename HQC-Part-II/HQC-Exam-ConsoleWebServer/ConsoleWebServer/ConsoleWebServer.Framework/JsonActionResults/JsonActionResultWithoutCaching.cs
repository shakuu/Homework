using System;
using System.Collections.Generic;
using ConsoleWebServer.Framework;

public class JsonActionResultWithoutCaching : JsonActionResult
{
    public JsonActionResultWithoutCaching(HttpRequestManager r, object model)
        : base(r, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        throw new Exception();
    }
}