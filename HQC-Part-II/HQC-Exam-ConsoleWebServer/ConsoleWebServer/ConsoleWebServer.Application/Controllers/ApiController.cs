using System;
using System.Linq;
using ConsoleWebServer.Framework;

namespace ConsoleWebServer.Application.Controllers
{
    public class ApiController : Controller
    {
        public ApiController(HttpRequest request) : base(request)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;
            if (this.Request.Headers.ContainsKey("Referer"))
            {
                requestReferer = this.Request.Headers["Referer"].FirstOrDefault();
            }
            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException("Invalid referer!");
            }
            return new JsonActionResultWithCors(
                this.Request,
                new { date = DateTime.Now.ToString("yyyy-MM-dd"), moreInfo = "Data available for " + domainName },
                domainName);
            ;
        }
    }
}