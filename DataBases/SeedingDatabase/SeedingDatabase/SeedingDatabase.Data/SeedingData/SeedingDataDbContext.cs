using System.Data.Entity;

using SeedingDatabase.Models.Names;

namespace SeedingDatabase.Data.SeedingData
{
    public class SeedingDataDbContext : DbContext
    {
        public SeedingDataDbContext()
            : base("name=SeedingDataDb")
        {
        }

        public virtual IDbSet<Name> Names { get; set; }
    }
}
