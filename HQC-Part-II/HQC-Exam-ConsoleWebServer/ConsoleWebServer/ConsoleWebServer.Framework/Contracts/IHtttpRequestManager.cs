using System;
using System.Collections.Generic;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IHttpRequestManager
    {
        ActionDescriptor Action { get; }
        string Method { get; }
        Version ProtocolVersion { get; }
        IDictionary<string, ICollection<string>> Headers { get; }
        string Uri { get; }
        IHttpRequestManager Parse(string reqAsStr);
    }
}
