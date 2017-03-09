using System;
using System.Web.Mvc;

using AJAX.MoviesData;

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
            return View(new Movie());
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            var newMovie = this.movieService.Create(movie);

            return this.PartialView("_Details", (movie));
        }

        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            return this.PartialView("_Details", this.movieService.Find(id.Value));
        }

        [HttpGet]
        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Edit(Guid? id)
        {
            return this.PartialView("_UpdateForm", this.movieService.Find(id.Value));
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            this.movieService.Update(movie);

            return this.PartialView("_Details", movie);
        }

        [HttpPost]
        public ActionResult Delete(Guid? id)
        {
            this.movieService.Delete(id.Value);

            return this.PartialView("_CreateForm", new Movie());
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