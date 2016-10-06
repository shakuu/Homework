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
        private readonly IActionInvoker actionInvoker;
        private readonly Func<Version, HttpStatusCode, string, IHttpResponse> createResponse;

        public ResponseProvider(
            IHttpRequestManager requestManager,
            IActionInvoker actionInvoker,
            Func<Version, HttpStatusCode, string, IHttpResponse> createResponse)
        {
            if (requestManager == null)
            {
                throw new ArgumentNullException(nameof(requestManager));
            }

            if (this.actionInvoker == null)
            {
                throw new ArgumentNullException(nameof(actionInvoker));
            }

            if (createResponse == null)
            {
                throw new ArgumentNullException(nameof(createResponse));
            }

            this.requestManager = requestManager;
            this.actionInvoker = actionInvoker;
            this.createResponse = createResponse;
        }

        public IHttpResponse GetResponse(string requestAsString)
        {
            try
            {
                var resultHttpRequest = this.requestManager.Parse(requestAsString);
                var response = this.Process(resultHttpRequest);
                return response;
            }
            catch (HttpNotFoundException.ParserException ex)
            {
                var reponse = this.createResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
                return reponse;
            }
        }

        private IHttpResponse Process(IHttpRequest httpRequest)
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
                IHttpResponse response;
                try
                {
                    var controller = this.CreateController(httpRequest);
                    var actionResult = this.actionInvoker.InvokeAction(controller, httpRequest.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFoundException exception)
                {
                    response = this.createResponse(httpRequest.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = this.createResponse(httpRequest.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }

                return response;
            }
            else
            {
                return this.createResponse(httpRequest.ProtocolVersion, HttpStatusCode.NotImplemented, "RequestManager cannot be handled.");
            }
        }

        private Controller CreateController(IHttpRequest httpRequest)
        {
            var controllerClassName = httpRequest.Action.ControllerName + "Controller";
            var type = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(x =>
                    x.Name.ToLower() == controllerClassName.ToLower() &&
                    typeof(Controller).IsAssignableFrom(x));

            if (type == null)
            {
                throw new HttpNotFoundException(string.Format("Controller with name {0} not found!", controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, httpRequest);
            return instance;
        }
    }
}