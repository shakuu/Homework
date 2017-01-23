using System;
using System.Web.Mvc;

using WebFormsIntroduction.MVCClient.Models;

namespace WebFormsIntroduction.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(CalculatorViewModel model)
        {
            try
            {
                var valueA = decimal.Parse(model.ValueA);
                var valueB = decimal.Parse(model.ValueB);
                var sum = valueA + valueB;

                model.Result = sum.ToString();
            }
            catch (Exception)
            {
                model.Result = "Naughty!";
            }

            return View(model);
        }

        public ActionResult Index()
        {
            var model = new CalculatorViewModel();

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