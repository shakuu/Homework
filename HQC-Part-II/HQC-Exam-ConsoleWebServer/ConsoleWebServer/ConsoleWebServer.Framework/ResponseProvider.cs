using System;
using System.Linq;
using System.Net;
using System.Reflection;
using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework
{
    public class ResponseProvider : IResponseProvider
    {
        public ResponseProvider()
        {

        }

        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequestManager requestManager;
            try
            {
                var requestParser = new HttpRequestManager("GET", "/", "1.1");
                requestManager = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.Process(requestManager);
            return response;
        }

        private HttpResponse Process(HttpRequestManager requestManager)
        {
            if (requestManager.Method.ToLower() == "options")
            {
                var routes = Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                        .Select(x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                        .SelectMany(x => x.Methods.Select(m => string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                        .ToList();

                return new HttpResponse(requestManager.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }
            else if (new StaticFileHandler().CanHandle(requestManager))
            {
                return new StaticFileHandler().Handle(requestManager);
            }
            else if (requestManager.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    var controller = this.CreateController(requestManager);
                    var actionInvoker = new NewActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, requestManager.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFound exception)
                {
                    response = new HttpResponse(requestManager.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(requestManager.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }
                return response;
            }
            else
            {
                return new HttpResponse(requestManager.ProtocolVersion, HttpStatusCode.NotImplemented, "RequestManager cannot be handled.");
            }
        }

        private Controller CreateController(HttpRequestManager requestManager)
        {
            var controllerClassName = requestManager.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFound(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }
            var instance = (Controller)Activator.CreateInstance(type, requestManager);
            return instance;
        }
    }
}