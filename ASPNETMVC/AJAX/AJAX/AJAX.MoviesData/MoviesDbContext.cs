using System.Data.Entity;

namespace AJAX.MoviesData
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext()
            : base("name=MoviesMvcHomeworkDb")
        {

        }

        public virtual IDbSet<Movie> Movies { get; set; }
    }
}
