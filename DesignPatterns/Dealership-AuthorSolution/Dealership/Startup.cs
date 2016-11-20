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

            var engine = ninject.Get<IEngine>();
            engine.Start();
        }
    }
}
