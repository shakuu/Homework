using System;
using System.Reflection;

using Dealership.Common;
using Dealership.Engine;

using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            DealershipEngine.GetInstance(
                new Factories.DealershipFactory(),
                new GenericIOProvider(Console.Write, Console.ReadLine))
                .Start();
        }
    }
}
