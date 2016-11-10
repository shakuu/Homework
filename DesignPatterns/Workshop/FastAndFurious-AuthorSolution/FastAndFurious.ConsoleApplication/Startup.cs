using System.Reflection;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

using Ninject;

namespace FastAndFurious.ConsoleApplication
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var engine = ninject.Get<IEngine>();
            engine.Start();
        }
    }
}
