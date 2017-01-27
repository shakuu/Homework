using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsDataBinding.WebClient.Startup))]
namespace WebFormsDataBinding.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
