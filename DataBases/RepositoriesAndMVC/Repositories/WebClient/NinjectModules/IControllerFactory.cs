using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.NinjectModules
{
    public interface ICustomControllersFactory
    {
        Controller GetHome();
    }
}