using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.ContentActionResults;
using ConsoleWebServer.Framework.Contracts;

namespace ConsoleWebServer.Application.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequestManager requestManager) : base(requestManager)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.RequestManager, "Live page with no caching");
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.RequestManager, "Live page with no caching and CORS", "*");
        }
    }
}
