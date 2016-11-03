using DatabasePerformance.Models;
using System.Data.Entity;

namespace DatabasePerformance.Data
{
    public class PerformanceDbContext : DbContext
    {
        public PerformanceDbContext()
            : base("name=PerformanceDb")
        {

        }

        public virtual IDbSet<ModelWithIndex> ModelsWithIndex { get; set; }

        public virtual IDbSet<ModelWithoutIndex> ModelWithoutIndex { get; set; }
    }
}
