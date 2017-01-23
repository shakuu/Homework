using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsControls.WebFormsClient.Startup))]
namespace WebFormsControls.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
