using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_II.Models;
using Vidly_II.ViewModels;
using System.Data.Entity;

namespace Vidly_II.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _dbContext;


        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index(int? page, string sort)
        {

            var movies = _dbContext.Movies.Include(m=>m.Genre).ToList();

            var viewModel = new MoviesViewModel() { Movies = movies };

            return View(viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            return View(movie);
        }

        public ActionResult Create()
        {
            var genres = _dbContext.Genres.ToList();

            var viewModel = new AddEditMovieViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }

        public ActionResult Save(Movie movie)
        {

            if(movie.Id == 0)
            {
                DateTime dateTimeNow = DateTime.Now;

                movie.DateAdded = dateTimeNow;

                _dbContext.Movies.Add(movie);

                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");

            }
            else
            {
                var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Title = movie.Title;
                movieInDb.Image = movie.Image;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

                _dbContext.SaveChanges();
                return RedirectToAction("Details", "Movies", new { id=movie.Id});

            }

            
            
        }

        public ActionResult Edit(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AddEditMovieViewModel
            {
                Movie = movie,
                Genres = _dbContext.Genres.ToList()
            };

            return View("Create", viewModel);
        }

        //public ActionResult Index(int? page, string sort)
        //{

        //    var movie = new Movie() { Id = 7, Title = "Mission Impossible VII", Image = "" };
        //    var movie2 = new Movie() { Id = 8, Title = "Tenet", Image = "" };


        //    var movies = new List<Movie>();

        //    movies.Add(movie);
        //    movies.Add(movie2);

        //    var viewModel = new MoviesViewModel() { Movies = movies };

        //    return View(viewModel);
        //}

        public ActionResult ByReleaseDate(int? year, int month)
        {


            return Content(year + "/" + month);

        }


    }
}