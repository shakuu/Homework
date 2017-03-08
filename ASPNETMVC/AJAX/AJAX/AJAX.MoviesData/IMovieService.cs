using System.Collections.Generic;

namespace AJAX.MoviesData
{
    public interface IMovieService
    {
        Movie Create(Movie movie);

        IEnumerable<Movie> Read();

        Movie Update(Movie movie);

        Movie Delete(Movie movie);
    }
}
