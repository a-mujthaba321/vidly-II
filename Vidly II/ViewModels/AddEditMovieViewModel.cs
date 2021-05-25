using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_II.Models;

namespace Vidly_II.ViewModels
{
    public class AddEditMovieViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Image URL")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }


        public AddEditMovieViewModel()
        {
            Id = 0;

        }

        public AddEditMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Image = movie.Image;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;

        }
    }
}