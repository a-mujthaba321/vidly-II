using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_II.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}