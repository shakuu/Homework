using System.Collections.Generic;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.ContentActionResults
{
    public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    {
        public ContentActionResultWithCorsWithoutCaching(IHttpRequest requestManager, object model, string corsSettings) : base(requestManager, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}