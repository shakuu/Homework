using System;
using System.Collections.Generic;

public interface IHttpRequest
{
    ActionDescriptor Action { get; }
    string Method { get; }
    Version ProtocolVersion { get; }
    IDictionary<string, ICollection<string>> Headers { get; }
    string Uri { get; }
}