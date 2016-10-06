using System.Collections.Generic;
using System.Net;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Http;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.ContentActionResults
{
    public class ContentActionResult : IActionResult
    {
        private readonly object model;

        public ContentActionResult(IHttpRequest requestManager, object model)
        {
            this.model = model;
            this.RequestManager = requestManager;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public IHttpRequest RequestManager { get; private set; }

        public IList<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.RequestManager.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), "text/plain; charset=utf-8");
            foreach (var responseHeader in this.ResponseHeaders) { response.AddHeader(responseHeader.Key, responseHeader.Value); }
            return response;
        }

    }
}