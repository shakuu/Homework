using System;
using System.Linq;
using System.Net;
using System.Reflection;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Http.Contracts;
using ConsoleWebServer.Framework.Http.Exceptions;

namespace ConsoleWebServer.Framework.Http
{
    public class ResponseProvider : IResponseProvider
    {
        private readonly IHttpRequestManager requestManager;

        public ResponseProvider(IHttpRequestManager requestManager)
        {
            if (requestManager == null)
            {
                throw new ArgumentNullException(nameof(requestManager));
            }

            this.requestManager = requestManager;
        }

        public HttpResponse GetResponse(string requestAsString)
        {
            IHttpRequest resultHttpRequest;
            try
            {
                resultHttpRequest = this.requestManager.Parse(requestAsString);
            }
            catch (HttpNotFoundException.ParserException ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.Process(resultHttpRequest);
            return response;
        }

        private HttpResponse Process(IHttpRequest httpRequest)
        {
            if (httpRequest.Method.ToLower() == "options")
            {
                var routes = Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                        .Select(x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                        .SelectMany(x => x.Methods.Select(m => string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                        .ToList();

                return new HttpResponse(httpRequest.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }
            else if (new StaticFileHandler().CanHandle(httpRequest))
            {
                return new StaticFileHandler().Handle(httpRequest);
            }
            else if (httpRequest.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    var controller = this.CreateController(httpRequest);
                    var actionInvoker = new NewActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, httpRequest.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFoundException exception)
                {
                    response = new HttpResponse(httpRequest.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(httpRequest.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }
                return response;
            }
            else
            {
                return new HttpResponse(httpRequest.ProtocolVersion, HttpStatusCode.NotImplemented, "RequestManager cannot be handled.");
            }
        }

        private Controller CreateController(IHttpRequest httpRequest)
        {
            var controllerClassName = httpRequest.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));

            if (type == null)
            {
                throw new HttpNotFoundException(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }
            var instance = (Controller)Activator.CreateInstance(type, httpRequest);
            return instance;
        }
    }
}