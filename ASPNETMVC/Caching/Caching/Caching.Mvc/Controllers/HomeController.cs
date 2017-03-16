using System;
using System.Web.Mvc;
using Caching.Mvc.Models;

namespace Caching.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private const int CacheDurationInSeconds = 1 * 60 * 60;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}