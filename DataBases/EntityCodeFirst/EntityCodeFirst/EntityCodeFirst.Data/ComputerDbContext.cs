using System.Data.Entity;

using EntityCodeFirst.Models;

namespace EntityCodeFirst.Data
{
    public class ComputerDbContext : DbContext
    {
        public virtual IDbSet<PersonalComputer> Computers { get; set; }

        public virtual IDbSet<Motherboard> Motherboards { get; set; }
    }
}
