using System.Linq;
using System.Reflection;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Http.Exceptions;

namespace ConsoleWebServer.Framework
{
    public class ActionInvoker : IActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, HttpRequestWords httpRequestWords)
        {
            // * Child processes that use such C run-time functions as printf() and fprintf() can behave poorly when redirected.
            // * The C run - time functions maintain separate IO buffers.When redirected, these buffers might not be flushed immediately after each IO call.
            // * As a result, the output to the redirection pipe of a printf() call or the input from a getch() call is not flushed immediately and delays, sometimes - infinite delays occur.
            // * This problem is avoided if the child process flushes the IO buffers after each call to a C run - time IO function.
            // * Only the child process can flush its C run-time IO buffers. A process can flush its C run - time IO buffers by calling the fflush() function.

            var methodWithStringParameter = controller
                .GetType()
                .GetMethods()
                .FirstOrDefault(x =>
                    x.Name.ToLower() == httpRequestWords.ActionName.ToLower() &&
                    x.GetParameters().Length == 1 &&
                    x.GetParameters()[0].ParameterType == typeof(string) &&
                    x.ReturnType == typeof(IActionResult));

            if (methodWithStringParameter == null)
            {
                throw new HttpNotFoundException(
                    string.Format(
                        "Expected method with signature IActionResult {0}(string) in class {1}Controller",
                        httpRequestWords.ActionName, httpRequestWords.ControllerName));
            }

            try
            {
                var actionResult = (IActionResult)methodWithStringParameter.Invoke(controller, new object[] { httpRequestWords.Parameter });
                return actionResult;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}