using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebClient.NinjectModules
{
    public class MyControllerFactory : IControllerFactory
    {
        private readonly IControllersFactory factory;

        public MyControllerFactory(IControllersFactory factory)
        {
            this.factory = factory;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            return this.factory.GetHome();
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}