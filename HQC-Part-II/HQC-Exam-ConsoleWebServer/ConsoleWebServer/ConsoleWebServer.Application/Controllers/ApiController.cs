using System;
using System.Linq;
using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.JsonActionResults;

namespace ConsoleWebServer.Application.Controllers
{
    public class ApiController : Controller
    {
        public ApiController(HttpRequestManager requestManager) : base(requestManager)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;
            if (this.RequestManager.Headers.ContainsKey("Referer"))
            {
                requestReferer = this.RequestManager.Headers["Referer"].FirstOrDefault();
            }
            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException("Invalid referer!");
            }
            return new JsonActionResultWithCors(
                this.RequestManager,
                new { date = DateTime.Now.ToString("yyyy-MM-dd"), moreInfo = "Data available for " + domainName },
                domainName);
            ;
        }
    }
}