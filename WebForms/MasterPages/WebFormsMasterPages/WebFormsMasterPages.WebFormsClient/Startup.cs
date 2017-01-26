using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsMasterPages.WebFormsClient.Startup))]
namespace WebFormsMasterPages.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
