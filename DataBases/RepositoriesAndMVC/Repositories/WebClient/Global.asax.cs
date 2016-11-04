using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebClient.NinjectModules;

namespace WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ControllerBuilder.Current.SetControllerFactory();
            this.Experimenting();
        }

        private void Experimenting()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());
            var factory = ninject.Get<MyControllerFactory>();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}
