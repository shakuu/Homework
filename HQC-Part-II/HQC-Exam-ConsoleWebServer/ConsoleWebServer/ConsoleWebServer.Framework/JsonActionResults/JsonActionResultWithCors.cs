using System.Collections.Generic;

namespace ConsoleWebServer.Framework.JsonActionResults
{
    public class JsonActionResultWithCors : JsonActionResult
    {
        public JsonActionResultWithCors(IHttpRequest requestManager, object model, string corsSettings)
            : base(requestManager, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}