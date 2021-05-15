using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_II.Models;
using Vidly_II.ViewModels;

namespace Vidly_II.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Edit(int movieId)
        {
            return Content("ID = " + movieId);
        }

        public ActionResult Index(int? page, string sort)
        {

            var movie = new Movie() { Id = 7, Title = "Mission Impossible VII", Image = "https://ae01.alicdn.com/kf/HTB1PpkmXojrK1RkHFNRq6ySvpXag/Custom-Canvas-Wall-Mural-Tom-Cruise-Poster-Mission-Impossible-Fallout-Wall-Stickers-Rebecca-Ferguson-Wallpaper-Home.jpg" };
            var movie2 = new Movie() { Id = 8, Title = "Tenet", Image = "https://images-na.ssl-images-amazon.com/images/I/91oMmAPaaeL._AC_SL1500_.jpg" };


            var movies = new List<Movie>();

            movies.Add(movie);
            movies.Add(movie2);

            var viewModel = new MoviesViewModel() { Movies = movies };

            return View(viewModel);
        }

        public ActionResult ByReleaseDate(int? year, int month)
        {


            return Content(year + "/" + month);

        }


    }
}