using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using WebApplication1.Models;

namespace Vidly.Controllers
{
    /*
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            //Vraca stranicu na kojoj je ispisano Shrek!, ima i css i menu itd.
            return View(movie);

            //Vraca praznu stranicu na kojoj je samo Hello World!
            //return Content("Hello World!!!");

            //Vraca 404 error
            //return HttpNotFound();

            //Vraca praznu stranicu, uvek mora nova instanca EmptyResult klase
            //return new EmptyResult();

            //Redirect-uje na Home Controller, metoda Index tj. na Index action
            //Treci parametar je nacin na koji se prosledjuju parametri koji nam trebaju: preko anonimnog objekta...mozemo proslediti bilo sta
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});

        }

        // /movies/edit/1 ce vratiti stranu na kojoj pise id=1...ili /moveies/edit?id=1
        // ukoliko se id zameni sa movieId, mora se menjati i RouteConfig zato sto on sadrzi samo defaultni route: {controller}/{action}/{id}
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // rutiranje preko atributa u kontroleru, za constraints google ASP.NET MVC Attribute Route Constraints
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    } */

    //Section 2, Lecture 14
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random Primer stranice koja koristi ViewModel
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer{ Name = "Customer 1"},
        //        new Customer{ Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        public ActionResult Index()
        {
            //zahteva using system.data.entity import, ToList je da bi ih odmah povukao iz baze
            var allMovies= _context.Movies.Include(m => m.Genre).ToList();
            return View(allMovies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            var listOfMovies = new List<Movie>
            {
                new Movie { Id = 1, Name = "John Wick" },
                new Movie { Id = 2, Name = " The Equalizer" }
            };

            return listOfMovies;
        }
    }
}