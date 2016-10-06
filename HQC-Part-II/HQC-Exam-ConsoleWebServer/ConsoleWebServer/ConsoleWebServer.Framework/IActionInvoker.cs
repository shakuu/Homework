using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Framework
{
    public interface IActionInvoker
    {
        IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor);
    }
}