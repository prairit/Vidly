using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context=new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!newRental.MovieIds.Any())
                return BadRequest("No Movie are added.");

            var customer = _context.Customers.SingleOrDefault(e => e.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is invalid.");

            var movies = _context.Movies.Where(e => newRental.MovieIds.Contains(e.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest($"{movie.Name} Movie is unavailable.");
                movie.NumberAvailable--;
                var rental = new Rental
                {          
                    Customer = customer,
                    DateRented = DateTime.Now,
                    Movie = movie
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
