using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            DateAdded = movie.DateAdded;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }

        public IEnumerable<Genres> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public byte? NumberInStock { get; set; }

        public string Heading
        {
            get { return (Id == 0) ? "New Movie" : "Edit Movie"; }
        }
    }
}