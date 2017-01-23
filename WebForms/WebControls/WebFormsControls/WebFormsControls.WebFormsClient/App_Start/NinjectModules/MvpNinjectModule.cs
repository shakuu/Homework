using System;
using System.Linq;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsControls.WebFormsClient.App_Start.Factories;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace WebFormsControls.WebFormsClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Random>().ToSelf().InSingletonScope();

            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenter>().ToMethod(this.GetPresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenterFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorViewInstanceParameter = new Ninject.Parameters.ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorViewInstanceParameter);
        }
    }
}