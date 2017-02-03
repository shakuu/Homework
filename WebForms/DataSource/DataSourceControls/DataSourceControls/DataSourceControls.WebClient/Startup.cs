using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataSourceControls.WebClient.Startup))]
namespace DataSourceControls.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
