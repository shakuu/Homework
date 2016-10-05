using System;using System.Linq;
using System.Collections.Generic;using System.Text;
using System.Net;
using System.Text;

public class HttpResponse
{
    private string ServerEngineName;

    public HttpResponse(
        Version httpVersion,
        HttpStatusCode statusCode,
        string body,
        string contentType = "text/plain; charset=utf-8")
    {
        ServerEngineName = "ConsoleWebServer";
        ;
        ProtocolVersion = Version.Parse(httpVersion.ToString().ToLower().Replace("HTTP/".ToLower(), string.Empty));
        Headers = new SortedDictionary<string, ICollection<string>>();
        Body = body;
        StatusCode = statusCode;
        AddHeader("Server", ServerEngineName);
        AddHeader("Content-Length", body.Length.ToString());
        AddHeader("Content-Type", contentType);
    }

    public Version ProtocolVersion { get; protected set; }

    public IDictionary<string, ICollection<string>> Headers { get; protected set; }

    public void AddHeader(string name, string value)
    {
        if (!Headers.ContainsKey(name)){
            Headers.Add(name, new HashSet<string>());
        }
        Headers[name].Add(value);
    }

    public HttpStatusCode StatusCode { get; private set; }

    public string Body{get;private set; }

    public string StatusCodeAsString{get{return this.StatusCode.ToString();}}

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(
            string.Format(
                "{0}{1} {2} {3}",
                "HTTP/",
                ProtocolVersion,
                (int)StatusCode,
                StatusCodeAsString));
        var headerStringBuilder = new StringBuilder();
        foreach (var key in Headers.Keys)
        {
            headerStringBuilder.AppendLine(string.Format("{0}: {1}", key, string.Join("; ", Headers[key])));
        }
        stringBuilder.AppendLine(headerStringBuilder.ToString());
        if (!string.IsNullOrWhiteSpace(Body))
        {
            stringBuilder.AppendLine(Body);
        }
        return stringBuilder.ToString();
    }
}


































namespace ConsoleWebServer.Framework
{
    using System.Diagnostics;
    using System.Collections.Concurrent;
    using System;
}