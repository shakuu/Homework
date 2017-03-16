using System;
using System.IO;
using System.Reflection;
using System.Web.Caching;
using System.Web.Mvc;
using Caching.Mvc.Models;

namespace Caching.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private const int CacheDurationInSeconds = 1 * 60 * 60;
        private const string CacheItemName = "files";

        [HttpGet]
        [OutputCache(Duration = HomeController.CacheDurationInSeconds, VaryByParam = "none")]
        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.LastCacheTimestamp = DateTime.UtcNow;

            return View(viewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = HomeController.CacheDurationInSeconds, VaryByParam = "none")]
        public ActionResult Partial()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.LastCacheTimestamp = DateTime.UtcNow;

            return this.PartialView("_CachedPartial", viewModel);
        }

        [HttpGet]
        public ActionResult Files()
        {
            if (this.HttpContext.Cache[HomeController.CacheItemName] == null)
            {
                var executingAssebly = Assembly.GetExecutingAssembly().Location;

                var directory = Path.GetDirectoryName(executingAssebly);
                var files = Directory.GetFiles(directory);

                this.HttpContext.Cache.Add(HomeController.CacheItemName, files, new CacheDependency(directory), DateTime.UtcNow.AddMinutes(60), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            }

            return this.View(this.HttpContext.Cache[HomeController.CacheItemName]);
        }
    }
}