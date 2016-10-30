using System.ComponentModel.DataAnnotations;

namespace Data.CodeFirst.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
