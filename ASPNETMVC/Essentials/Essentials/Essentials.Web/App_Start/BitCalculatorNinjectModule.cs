using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;

using Essentials.BitCalculator;

namespace Essentials.Web.App_Start
{
    public class BitCalculatorNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindAllClasses);
            this.Bind(this.BindFactories);

            this.Bind<IBitCalculatorResultsContainerEditable>().To<BitCalculatorResultsContainer>();
        }

        private void BindAllClasses(IFromSyntax binding)
        {
            binding
                .FromAssembliesMatching("*.BitCalculator.*")
                .SelectAllClasses()
                .BindDefaultInterface()
                .ConfigureFor<BitCalculator.BitCalculator>(c => c.InSingletonScope());
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