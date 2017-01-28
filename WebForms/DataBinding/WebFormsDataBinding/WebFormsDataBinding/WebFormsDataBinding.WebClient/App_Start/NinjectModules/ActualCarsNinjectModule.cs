using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsDataBinding.ActualCars.Models.Factories;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class ActualCarsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssembliesMatching("WebFormsDataBinding.ActualCars").SelectAllClasses().BindDefaultInterface());

            this.Bind<ICreateCarFormModelsFactory>().ToFactory().InSingletonScope();
        }
    }
}