using System.Data.Entity;

using DatabasePerformance.Data.MySql.Models;

using MySql.Data.Entity;

namespace DatabasePerformance.Data.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlPerformanceDbContext : DbContext
    {
        public MySqlPerformanceDbContext()
            : base("name=MySqlPerformanceDb")
        {

        }

        public virtual IDbSet<MySqlModel> MySqlModels { get; set; }
    }
}
