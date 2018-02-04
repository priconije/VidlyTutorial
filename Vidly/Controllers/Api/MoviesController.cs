using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using WebApplication1.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }
         
        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        // POST /api/movies/1
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newMovie = Mapper.Map<MovieDTO, Movie>(movie);

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            movie.Id = newMovie.Id;

            return Created(Request.RequestUri + "/" + movie.Id, movie);
        }

        // PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDTO movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map<MovieDTO, Movie>(movie, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
