using System;

using Dealership.Common.Contracts;
using Dealership.Common;
using Dealership.Factories;

using Ninject.Modules;

namespace Dealership.NinjectBindings
{
    public class DealershipBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDealershipFactory>().To<DealershipFactory>();
            this.Bind<IIOProvider>().ToMethod(io => new GenericIOProvider(Console.Write, Console.ReadLine));
        }
    }
}
