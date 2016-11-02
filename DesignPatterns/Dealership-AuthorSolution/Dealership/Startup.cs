using System.Reflection;

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

            Startup.SingletonTest(ninject);

            var engine = ninject.Get<IEngine>();
            engine.Start();
        }

        private static void SingletonTest(StandardKernel ninjectKernel)
        {
            var firstInstace = ninjectKernel.Get<IEngine>();
            var secondInstance = ninjectKernel.Get<IEngine>();
            var isSameReference = firstInstace == secondInstance;

            System.Console.WriteLine($"{nameof(firstInstace)} and {nameof(secondInstance)} reference the same instance: {isSameReference}");
        }
    }
}
