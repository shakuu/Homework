using AJAX.MoviesData;

namespace AJAX.Web.Models
{
    public class MovieViewModel
    {
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