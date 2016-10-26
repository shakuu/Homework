using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models.StudentSystem
{
    public class CourseMaterial
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Url)]
        [StringLength(200, MinimumLength = 3)]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
