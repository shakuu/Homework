public abstract class Controller
{
    public HttpRq Request{get; private set;}
    protected IActionResult Content(object model){return new ContentActionResult(this.Request, model);}
    protected IActionResult Json(object model){return new JsonActionResult(this.Request, model);}
    protected Controller(HttpRq r){this.Request = r;}
}
