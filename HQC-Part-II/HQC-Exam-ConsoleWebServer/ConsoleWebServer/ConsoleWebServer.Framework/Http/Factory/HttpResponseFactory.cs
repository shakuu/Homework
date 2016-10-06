using System;
using System.Net;
using ConsoleWebServer.Framework.Http.Contracts;

namespace ConsoleWebServer.Framework.Http.Factory
{
    public static class HttpResponseFactory
    {
        public static IHttpResponse CreateHttpResponse(
            Version httpVersion, HttpStatusCode statusCode, 
            string body,
            string contentType = "text/plain; charset=utf-8")
        {
            var httpResponse = new HttpResponse(httpVersion, statusCode, body, contentType);
            return httpResponse;
        }
    }
}
