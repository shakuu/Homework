using System.Data.Entity;

namespace StateManagement.WebClient
{
    public class ApplicationsDbContext : DbContext
    {
        public ApplicationsDbContext()
            : base("name=ApplicationsDb")
        {
        }

        public virtual DbSet<ApplicationModel> ApplicationModels { get; set; }
    }
}