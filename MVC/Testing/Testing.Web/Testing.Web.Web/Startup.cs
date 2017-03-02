using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testing.Web.Web.Startup))]
namespace Testing.Web.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
