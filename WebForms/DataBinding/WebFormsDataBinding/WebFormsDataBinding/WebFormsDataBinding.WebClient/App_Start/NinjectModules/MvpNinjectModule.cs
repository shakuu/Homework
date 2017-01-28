using System;
using System.Linq;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using WebFormsMvp.Binder;

using WebFormsDataBinding.WebClient.App_Start.Factories;
using WebFormsMvp;
using WebFormsDataBinding.Cars.Services.Contracts;
using WebFormsDataBinding.Cars.Services;
using WebFormsDataBinding.Cars.Presenters.Contracts;
using WebFormsDataBinding.Cars.Presenters;

namespace WebFormsDataBinding.WebClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICarsService>().To<CarsService>().InSingletonScope();
            this.Bind<ICarsPresenter>().To<CarsPresenter>();

            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.GetPresenter).NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}