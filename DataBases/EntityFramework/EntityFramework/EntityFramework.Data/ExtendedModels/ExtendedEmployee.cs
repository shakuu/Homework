using System.Data.Linq;

namespace EntityFramework.Data
{
    public partial class Employee
    {
        public EntitySet<Territory> EntitySetTerritories
        {
            get
            {
                return this.GetTerritoryNames();
            }
        }

        private EntitySet<Territory> GetTerritoryNames()
        {
            var result = new EntitySet<Territory>();
            result.Assign(this.Territories);
            return result;
        }
    }
}
