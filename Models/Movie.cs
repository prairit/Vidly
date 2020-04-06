using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genres Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }

    public class Genres
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }

}