using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsIntroPartTwo.WebFormsClient.Startup))]
namespace WebFormsIntroPartTwo.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
