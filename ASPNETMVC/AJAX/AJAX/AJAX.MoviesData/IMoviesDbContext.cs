using System.Data.Entity;

namespace AJAX.MoviesData
{
    public interface IMoviesDbContext
    {
        IDbSet<Movie> Movies { get; set; }
    }
}
