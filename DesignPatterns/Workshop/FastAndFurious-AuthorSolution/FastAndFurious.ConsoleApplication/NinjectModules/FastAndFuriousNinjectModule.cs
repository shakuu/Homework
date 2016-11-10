using System.IO;
using System.Reflection;

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
        }
    }
}
