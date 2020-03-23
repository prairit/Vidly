using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
            return View(getList());
        }

        public ActionResult Details(int id)
        {
            return View(getList().SingleOrDefault(e => e.Id == id));
        }
    }
}