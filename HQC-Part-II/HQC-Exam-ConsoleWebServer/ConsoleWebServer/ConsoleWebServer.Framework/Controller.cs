using ConsoleWebServer.Framework.ContentActionResults;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Http.Contracts;
using ConsoleWebServer.Framework.JsonActionResults;

namespace ConsoleWebServer.Framework
{
    public abstract class Controller
    {
        protected Controller(IHttpRequest requestManager)
        {
            this.RequestManager = requestManager;
        }

        public IHttpRequest RequestManager { get; private set; }
        
        protected IActionResult Content(object model)
        {
            return new ContentActionResult(this.RequestManager, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResult(this.RequestManager, model);
        }

    }
}
