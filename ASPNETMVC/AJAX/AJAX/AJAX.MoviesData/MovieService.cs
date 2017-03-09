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

        public Movie Delete(Movie movie)
        {
            this.moviesDbContext.Movies.Remove(movie);
            this.moviesDbContext.SaveChanges();

            return movie;
        }
    }
}
