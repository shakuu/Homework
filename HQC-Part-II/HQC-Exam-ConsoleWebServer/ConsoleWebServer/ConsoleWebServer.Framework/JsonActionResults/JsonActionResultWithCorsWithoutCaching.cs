using System.Collections.Generic;
using ConsoleWebServer.Framework.Http;

namespace ConsoleWebServer.Framework.JsonActionResults
{
    public class JsonActionResultWithCorsWithoutCaching : JsonActionResult
    {
        public JsonActionResultWithCorsWithoutCaching(HttpRequestManager requestManager, object model, string corsSettings)
            : base(requestManager, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}