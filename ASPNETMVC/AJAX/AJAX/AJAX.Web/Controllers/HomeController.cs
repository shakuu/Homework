using System.Web.Mvc;

using AJAX.MoviesData;

namespace AJAX.Web.Controllers
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            this.movieService.Create(movie);

            return View();
        }

        [HttpPost]
        public ActionResult Read()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}