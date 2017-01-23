using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsIntroduction.WebFormsClient.Startup))]
namespace WebFormsIntroduction.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
