using ConsoleWebServer.Framework;

namespace ConsoleWebServer.Application.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.Request, "Live page with no caching");
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.Request, "Live page with no caching and CORS", "*");
        }
    }
}
