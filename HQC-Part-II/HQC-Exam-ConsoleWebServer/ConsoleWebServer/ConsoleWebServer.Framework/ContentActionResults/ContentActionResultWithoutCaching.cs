using System.Collections.Generic;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.ContentActionResults
{
    public class ContentActionResultWithoutCaching : ContentActionResult
    {
        public ContentActionResultWithoutCaching(IHttpRequest requestManager, object model) : base(requestManager, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}