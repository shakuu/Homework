using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace StateManagement.WebClient
{
    public class Global : System.Web.HttpApplication
    {
        public const string RequestsCount = "RequestsCount";

        protected void Application_Start(object sender, EventArgs e)
        {
            this.Application[Global.RequestsCount] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var currentCount = (int)this.Application[Global.RequestsCount];
            this.Application[Global.RequestsCount] = currentCount + 1;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}