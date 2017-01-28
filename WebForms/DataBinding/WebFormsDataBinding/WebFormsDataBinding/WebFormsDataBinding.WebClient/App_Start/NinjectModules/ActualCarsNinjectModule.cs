using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsDataBinding.ActualCars.Models.Factories;
using WebFormsDataBinding.ActualCars.Services;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class ActualCarsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<ICreateCarFormModelsFactory>().SelectAllClasses().BindDefaultInterface());

            this.Rebind<CarsInformationService>().ToSelf().InSingletonScope();

            this.Bind<ICreateCarFormModelsFactory>().ToFactory().InSingletonScope();
        }
    }
}