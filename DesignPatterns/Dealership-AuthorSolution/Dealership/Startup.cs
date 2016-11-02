using System.Reflection;

using Dealership.Common.Contracts;
using Dealership.CommandHandlers.Contracts;
using Dealership.Engine;
using Dealership.Factories;

using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var factory = ninject.Get<IDealershipFactory>();
            var ui = ninject.Get<IIOProvider>();
            var commandHandler = ninject.Get<ICommandHandler>();

            DealershipEngine.GetInstance(factory, ui, commandHandler).Start();
        }
    }
}
