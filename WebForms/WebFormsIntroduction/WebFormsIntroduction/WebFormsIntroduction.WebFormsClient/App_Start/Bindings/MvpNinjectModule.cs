using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using WebFormsMvp.Binder;

using WebFormsIntroduction.WebFormsClient.App_Start.PresenterFactories;
using WebFormsMvp;
using Ninject.Activation;

namespace WebFormsIntroduction.WebFormsClient.App_Start.Bindings
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(this.CreatePresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter CreatePresenterFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var viewInstanceCtorArgument = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, viewInstanceCtorArgument);
        }
    }
}