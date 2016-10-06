using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Contracts;

public abstract class Controller
{
    public HttpRequestManager RequestManager{get; private set;}
    protected IActionResult Content(object model){return new ContentActionResult(this.RequestManager, model);}
    protected IActionResult Json(object model){return new JsonActionResult(this.RequestManager, model);}
    protected Controller(HttpRequestManager r){this.RequestManager = r;}
}
