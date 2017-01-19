using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Binder;
using WebFormsTest.mvp;

namespace WebFormsTest.App_Start
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<LookupStudentPresenter>().To<LookupStudentPresenter>();
            this.Bind<IStudentRepository>().To<StudentRepository>();

            this.Bind<IPresenterFactory>()
                .To<MyFactory>()
                .InSingletonScope();

            this.Bind<ICustomPresenterFactory>()
                .ToFactory()
                .InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(this.PresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null, null));
        }

        private IPresenter PresenterFactoryMethod(IContext ctx)
        {
            var parameters = ctx.Parameters.ToList();

            var requestedType = (Type)parameters[0].GetValue(ctx, null);
            if (requestedType == null)
            {
                throw new ArgumentNullException("Invalid requested presenter type.");
            }

            var viewType = (Type)parameters[1].GetValue(ctx, null);
            var viewTypeInterface = viewType.GetInterfaces().FirstOrDefault(x => x.Name.Contains("View") && !x.Name.Contains("IView"));
            if (viewTypeInterface == null)
            {
                throw new ArgumentNullException("Invalid requested view type.");
            }

            var viewInstance = (IView)parameters[2].GetValue(ctx, null);
            if (viewInstance == null)
            {
                viewInstance = (IView)ctx.Kernel.Get(viewType);
            }

            // Unknown possible parameters for each separate IPresenter
            // Binding the view so Ninject can resolve each of them separately.
            //var bindingExists = this.Kernel.GetBindings(viewTypeInterface).Any();
            //if (bindingExists)
            //{
            //    this.Rebind(viewTypeInterface).ToMethod(context => viewInstance);
            //}
            //else
            //{
            //    this.Bind(viewTypeInterface).ToMethod(context => viewInstance);
            //}

            var viewInstanceParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)ctx.Kernel.Get(requestedType, viewInstanceParameter);
        }
    }
}