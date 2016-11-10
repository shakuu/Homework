using System.IO;
using System.Reflection;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Engine;

using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace FastAndFurious.ConsoleApplication.NinjectBindings
{
    public class FastAndFuriousNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(ctx =>
                ctx.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .SelectAllClasses()
                    .BindDefaultInterface());

            this.Bind<IInputOutputProvider>().To<ConsoleInputOutputProvider>()
                .WhenInjectedInto<Engine.Engine>();
        }
    }
}
