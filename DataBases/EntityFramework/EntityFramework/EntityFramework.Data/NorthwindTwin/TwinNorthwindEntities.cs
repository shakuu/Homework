using EntityFramework.Data;

namespace EntityFramework.Data.NorthwindTwin
{
    public class TwinNorthwindEntities : NorthwindEntities
    {
        public TwinNorthwindEntities(string connectionString)
           : base($"name={connectionString}")
        {
        }
    }
}
