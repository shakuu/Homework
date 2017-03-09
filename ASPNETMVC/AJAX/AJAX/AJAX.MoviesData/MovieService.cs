using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AJAX.MoviesData
{
    public class MovieService : IMovieService
    {
        private readonly IMoviesDbContext moviesDbContext;

        public MovieService(IMoviesDbContext moviesDbContext)
        {
            this.moviesDbContext = moviesDbContext;
        }

        public Movie Find(Guid id)
        {
            return this.moviesDbContext.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie Create(Movie movie)
        {
            this.moviesDbContext.Movies.Add(movie);
            this.moviesDbContext.SaveChanges();

            return movie;
        }

        public IEnumerable<Movie> Read()
        {
            return this.moviesDbContext.Movies.ToList();
        }

        public Movie Update(Movie movie)
        {
            var entry = this.moviesDbContext.Entry(movie);
            entry.State = EntityState.Modified;

            this.moviesDbContext.SaveChanges();

            return movie;
        }

        public Movie Delete(Guid id)
        {
            var movie = this.Find(id);
            var entry = this.moviesDbContext.Entry(movie);
            entry.State = EntityState.Deleted;

            this.moviesDbContext.SaveChanges();

            return movie;
        }
    }
}
