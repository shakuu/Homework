using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework
{
    public class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            var className = HttpNotFound.ClassName;
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}
