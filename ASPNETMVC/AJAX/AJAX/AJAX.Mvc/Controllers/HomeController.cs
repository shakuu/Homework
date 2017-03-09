using System;
using System.Web.Mvc;

using AJAX.MoviesData;
using AJAX.Mvc.Models;

namespace AJAX.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new MovieViewModel());
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            this.movieService.Create(movie);

            return this.RedirectToAction("Details", new { id = movie.Id });
        }

        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            return Content("working");
        }

        [HttpGet]
        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            return this.Redirect("Details");
        }

        [HttpPost]
        public ActionResult Delete(Guid? id)
        {
            return this.Redirect("Index");
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