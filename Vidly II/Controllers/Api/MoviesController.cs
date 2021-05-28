using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_II.Dtos;
using Vidly_II.Models;

namespace Vidly_II.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            return _dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == Id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            DateTime dateTimeNow = DateTime.Now;

            movie.DateAdded = dateTimeNow;

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/"+ movie.Id), movieDto);

        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == Id);

            if(movieInDb == null)
            {
                return NotFound();
            }

            movieInDb = Mapper.Map(movieDto, movieInDb);

            _dbContext.SaveChanges();


            return Ok(movieInDb);

        }

        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == Id);

            if(movieInDb == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
