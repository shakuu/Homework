using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;

namespace Essentials.Web.App_Start
{
    public class BitCalculatorNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindAllClasses);
            this.Bind(this.BindFactories);
        }

        private void BindAllClasses(IFromSyntax binding)
        {
            binding
                .FromAssembliesMatching("*.BitCalculator.*")
                .SelectAllClasses()
                .BindDefaultInterface();
        }

        private void BindFactories(IFromSyntax binding)
        {
            binding
                .FromAssembliesMatching("*.BitCalculator.*")
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(f => f.InSingletonScope());
        }
    }
}