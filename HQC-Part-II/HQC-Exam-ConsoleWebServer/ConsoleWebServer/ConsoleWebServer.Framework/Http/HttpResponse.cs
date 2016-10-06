using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.Http
{
    public class HttpResponse : IHttpResponse
    {
        private const string ServerEngineName = "ConsoleWebServer";

        public HttpResponse(Version httpVersion, HttpStatusCode statusCode, string body, string contentType = "text/plain; charset=utf-8")
        {
            this.ProtocolVersion = Version.Parse(httpVersion.ToString().ToLower().Replace("HTTP/".ToLower(), string.Empty));
            this.Headers = new SortedDictionary<string, ICollection<string>>();
            this.Body = body;
            this.StatusCode = statusCode;
            this.AddHeader("Server", HttpResponse.ServerEngineName);
            this.AddHeader("Content-Length", body.Length.ToString());
            this.AddHeader("Content-Type", contentType);
        }

        private Version ProtocolVersion { get; set; }

        private IDictionary<string, ICollection<string>> Headers { get; set; }

        private HttpStatusCode StatusCode { get; set; }

        private string Body { get; set; }

        private string StatusCodeAsString
        {
            get
            {
                return this.StatusCode.ToString();
            }
        }

        public void AddHeader(string name, string value)
        {
            if (!this.Headers.ContainsKey(name))
            {
                this.Headers.Add(name, new HashSet<string>());
            }

            this.Headers[name].Add(value);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                string.Format(
                    "{0}{1} {2} {3}",
                    "HTTP/",
                    this.ProtocolVersion,
                    (int)this.StatusCode,
                    this.StatusCodeAsString));
            var headerStringBuilder = new StringBuilder();
            foreach (var key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format("{0}: {1}", key, string.Join("; ", this.Headers[key])));
            }

            stringBuilder.AppendLine(headerStringBuilder.ToString());
            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                stringBuilder.AppendLine(this.Body);
            }

            return stringBuilder.ToString();
        }
    }
}