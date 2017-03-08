using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJAX.MoviesData
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public string LeadingMaleRole { get; set; }

        public string LeadingFemaleRole { get; set; }

        public int LeadingMaleRoleAge { get; set; }

        public int LeadingFemaleRoleAge { get; set; }

        public string Studio { get; set; }

        public string StudioAddress { get; set; }
    }
}
