using System;
using System.Data.Entity;

using AJAX.MessagesWebClient.Migrations;

namespace AJAX.MessagesWebClient
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MessagesDbContext, Configuration>());
        }
    }
}