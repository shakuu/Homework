using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace AJAX.MoviesData
{
    public interface IMoviesDbContext
    {
        IDbSet<Movie> Movies { get; set; }

        DbEntityEntry Entry(object entity);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
