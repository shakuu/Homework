using System;

using Ninject.Extensions.Interception;

namespace FastAndFurious.ConsoleApplication.NinjectModules.Interceptors
{
    public class ConsoleReadlineInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            
            invocation.ReturnValue = Console.ReadLine();
        }
    }
}
