using System.Data.Entity;

using DatabasePerformance.Models;

namespace DatabasePerformance.Data
{
    public class PerformanceDbContext : DbContext
    {
        public PerformanceDbContext()
            : base("name=PerformanceDb")
        {

        }

        public virtual IDbSet<ModelWithIndex> ModelsWithIndex { get; set; }

        public virtual IDbSet<ModelWithoutIndex> ModelsWithoutIndex { get; set; }

        public virtual IDbSet<ModelWithTwoIndexes> ModelsWithTwoIndexes { get; set; }
    }
}
