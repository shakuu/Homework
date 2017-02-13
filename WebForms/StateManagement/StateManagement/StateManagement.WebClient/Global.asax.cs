using StateManagement.WebClient.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace StateManagement.WebClient
{
    public class Global : System.Web.HttpApplication
    {
        public const string RequestsCount = "RequestsCount";
        public const string RequestsCountFromDb = "RequestsCountFromDb";
        public const string AppName = "Homework";

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationsDbContext, Configuration>());

            var db = new ApplicationsDbContext();
            var app = db.ApplicationModels.FirstOrDefault(application => application.Name == Global.AppName);
            if (app == null)
            {
                var newApp = new ApplicationModel();
                newApp.Name = Global.AppName;

                db.ApplicationModels.Add(newApp);
                db.SaveChanges();

                this.Application[Global.RequestsCountFromDb] = 0;
            }
            else
            {
                this.Application[Global.RequestsCountFromDb] = app.RequestsCount;
            }

            this.Application[Global.RequestsCount] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var currentCount = (int)this.Application[Global.RequestsCount];
            this.Application[Global.RequestsCount] = currentCount + 1;

            var currentCountDb = (int)this.Application[Global.RequestsCountFromDb];
            this.Application[Global.RequestsCountFromDb] = currentCountDb + 1;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var db = new ApplicationsDbContext();
            var app = db.ApplicationModels.FirstOrDefault(application => application.Name == Global.AppName);
            app.RequestsCount = (int)this.Application[Global.RequestsCountFromDb];

            db.SaveChanges();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            var db = new ApplicationsDbContext();
            var app = db.ApplicationModels.FirstOrDefault(application => application.Name == Global.AppName);
            app.RequestsCount = (int)this.Application[Global.RequestsCountFromDb];

            db.SaveChanges();
        }
    }
}