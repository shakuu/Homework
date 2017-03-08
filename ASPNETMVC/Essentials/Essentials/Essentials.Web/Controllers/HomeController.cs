using System.Web.Mvc;

using Essentials.BitCalculator;
using Essentials.Web.Models;

namespace Essentials.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBitCalculator bitCalculator;

        public HomeController(IBitCalculator bitCalculator)
        {
            this.bitCalculator = bitCalculator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            model.BitCalculatorResultsContainer = this.bitCalculator.Calculate(model.Quantity, model.UnitType);

            return View(model);
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