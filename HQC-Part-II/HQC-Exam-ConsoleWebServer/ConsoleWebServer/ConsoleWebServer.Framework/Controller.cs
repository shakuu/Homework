using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework
{
    public abstract class Controller
    {
        public IHttpRequestManager RequestManager { get; private set; }

        protected Controller(HttpRequestManager r)
        {
            this.RequestManager = r;
        }

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
