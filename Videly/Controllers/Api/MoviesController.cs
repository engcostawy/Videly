using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videly.Models;
using System.Data.Entity;

namespace Videly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<Movie> GetMovies()
        {
            var movies = _context.Movies.Include(e=>e.Genre).ToList();
            return movies;
        }

        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(e => e.Id == id);
            return movie;
        }

        [HttpPost]
        public Movie SetMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        [HttpPut]
        public void UpdateMovie(int Id,Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var mov = _context.Movies.SingleOrDefault(e => e.Id == Id);
            if (mov == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            mov.Name = movie.Name;
            mov.NumberInStock = movie.NumberInStock;
            mov.ReleaseDate = movie.ReleaseDate;
            mov.GenreId = movie.GenreId;
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(e => e.Id == id);
            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
        }
    }
}
