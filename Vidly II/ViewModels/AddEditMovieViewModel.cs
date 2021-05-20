using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_II.Models;

namespace Vidly_II.ViewModels
{
    public class AddEditMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}