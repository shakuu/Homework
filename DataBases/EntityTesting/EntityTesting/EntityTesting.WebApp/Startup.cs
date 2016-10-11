using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityTesting.WebApp.Startup))]
namespace EntityTesting.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
