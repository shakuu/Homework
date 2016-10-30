using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.CodeFirst.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Cityid { get; set; }

        public virtual City City { get; set; }
    }
}
