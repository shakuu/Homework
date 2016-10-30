using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.CodeFirst.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
