using System;
using System.IO;
using System.Net;

using ConsoleWebServer.Framework.Http;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework
{
    public class StaticFileHandler : IStaticFileHandler
    {
        public bool CanHandle(IHttpRequest requestManager)
        {
            return requestManager.Uri.LastIndexOf(".", StringComparison.Ordinal)
                   > requestManager.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        public IHttpResponse Handle(IHttpRequest requestManager)
        {
            var filePath = Environment.CurrentDirectory + "/" + requestManager.Uri;
            if (!this.FileExists(filePath))
            {
                return new HttpResponse(requestManager.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
            }

            var fileContents = File.ReadAllText(filePath);
            var response = new HttpResponse(requestManager.ProtocolVersion, HttpStatusCode.OK, fileContents);
            return response;
        }

        private bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}