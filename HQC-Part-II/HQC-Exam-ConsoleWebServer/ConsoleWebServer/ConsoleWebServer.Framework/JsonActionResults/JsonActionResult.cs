using System.Collections.Generic;
using System.Net;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Http.Contracts;
using Newtonsoft.Json;

namespace ConsoleWebServer.Framework.JsonActionResults
{
    public class JsonActionResult : IActionResult
    {
        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }
        public JsonActionResult(IHttpRequest requestManager, object m)
        {
            this.model = m;
            this.RequestManager = requestManager;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }
        public IHttpRequest RequestManager { get; private set; }
        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }
        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.model);
        }
        public readonly object model;
        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.RequestManager.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }
            return response;
        }
    }
}