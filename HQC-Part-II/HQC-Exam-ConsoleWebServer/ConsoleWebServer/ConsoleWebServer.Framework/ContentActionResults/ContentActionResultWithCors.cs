using System.Collections.Generic;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.ContentActionResults
{
    public class ContentActionResultWithCors<TResult> : ContentActionResult
    {
        public ContentActionResultWithCors(IHttpRequest requestManager, object model, string corsSettings) : base(requestManager, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}