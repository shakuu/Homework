using System.Collections.Generic;
using System.Net;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Http;
using ConsoleWebServer.Framework.Http.Contracts;

using Newtonsoft.Json;

namespace ConsoleWebServer.Framework.JsonActionResults
{
    public class JsonActionResult : IActionResult
    {
        private readonly object model;

        public JsonActionResult(IHttpRequest requestManager, object model)
        {
            this.model = model;
            this.RequestManager = requestManager;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }
        protected List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        private IHttpRequest RequestManager { get; set; }

        public IHttpResponse GetResponse()
        {
            var response = new HttpResponse(this.RequestManager.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }

        protected virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        private string GetContent()
        {
            return JsonConvert.SerializeObject(this.model);
        }
    }
}