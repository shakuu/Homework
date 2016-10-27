using SeedingDatabase.Models.Names.Enums;

namespace SeedingDatabase.Models.Names
{
    public class Name
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType GenderType { get; set; }
    }
}
