using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebFormsMvp;
using WebFormsMvp.Binder;
using WebFormsTest.mvp;

namespace WebFormsTest
{
    public class Global : HttpApplication
    {
        public static IKernel ninjectKernel;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            PresenterBinder.Factory = Global.ninjectKernel.Get<IPresenterFactory>();
        }
    }

    public class MyFactory : IPresenterFactory
    {
        private ICustomPresenterFactory factory;

        public MyFactory(ICustomPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            var instance = this.factory.GetPresenter(presenterType, viewType, viewInstance);
            return instance;
        }

        public void Release(IPresenter presenter)
        {
            throw new NotImplementedException();
        }
    }
}