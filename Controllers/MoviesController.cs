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

        public ActionResult List()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Movie> listMovies = _context.Movies.Include(e => e.Genre);
            return View(listMovies.SingleOrDefault(e => e.Id == id));
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var model=new MovieFormViewModel()
            {
                Genres = _context.Genres
            };
            return View("MovieForm",model);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var model=new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres
                };
                return View("MovieForm",model);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded=DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
                _context.Entry(movie).State = System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();

            return RedirectToAction("List");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(e => e.Id == id);

            if (movie == null)
                return HttpNotFound();

            var model=new MovieFormViewModel(movie)
            {
                Genres = _context.Genres
            };
            return View("MovieForm",model);
        }
    }
}