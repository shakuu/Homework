using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeedingDatabase.Models.Courses
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Description { get; set; }
    }
}
