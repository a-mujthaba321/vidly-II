using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_II.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}