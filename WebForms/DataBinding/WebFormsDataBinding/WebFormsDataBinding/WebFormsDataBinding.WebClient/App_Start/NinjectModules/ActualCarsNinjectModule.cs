using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsDataBinding.ActualCars.Models.Factories;
using WebFormsDataBinding.ActualCars.Services;
using WebFormsDataBinding.ActualCars.Services.Contracts;

using WebFormsDataBinding.Cars.Presenters;
using WebFormsDataBinding.Cars.Presenters.Contracts;
using WebFormsDataBinding.Cars.Services;
using WebFormsDataBinding.Cars.Services.Contracts;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class ActualCarsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<ICreateCarFormModelsFactory>().SelectAllClasses().BindDefaultInterface());

            this.Rebind<ICarsInformationService>().To<CarsInformationService>().InSingletonScope();

            this.Bind<ICreateCarFormModelsFactory>().ToFactory().InSingletonScope();


            this.Bind<ICarsService>().To<CarsService>().InSingletonScope();
            this.Bind<ICarsPresenter>().To<CarsPresenter>();
        }
    }
}