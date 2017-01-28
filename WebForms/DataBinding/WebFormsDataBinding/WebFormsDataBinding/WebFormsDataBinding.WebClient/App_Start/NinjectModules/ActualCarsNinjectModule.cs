﻿using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsDataBinding.ActualCars.Models.Factories;
using WebFormsDataBinding.ActualCars.Services;
using WebFormsDataBinding.ActualCars.Services.Contracts;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class ActualCarsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<ICreateCarFormModelsFactory>().SelectAllClasses().BindDefaultInterface());

            this.Rebind<ICarsInformationService>().To<CarsInformationService>().InSingletonScope();

            this.Bind<ICreateCarFormModelsFactory>().ToFactory().InSingletonScope();
        }
    }
}