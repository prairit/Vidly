using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var Movie = new Movie()
            {
                Name = "Johny English"
            };

            var List=new List<Customer>
            {
                new Customer{Id = 1,Name = "Prairit"},
                new Customer{Id = 2,Name = "Rachit"}
            };
            var viewModel=new RandomMovieViewModel{Customers = List,Movie = Movie};
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }

        private List<Movie> getList()
        {
            List < Movie> listMovie= new List<Movie>
            {
                new Movie{Id = 1,Name = "The Prestige"},
                new Movie{Id = 2,Name = "Minions"}
            };
            return listMovie;
        }

        public ActionResult List()
        {
            IEnumerable<Movie> listMovies = _context.Movies.Include(e =>e.Genre);
            return View(listMovies);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Movie> listMovies = _context.Movies.Include(e => e.Genre);
            return View(listMovies.SingleOrDefault(e => e.Id == id));
        }
    }
}