namespace EntityFrameworkCodeFirst.Models.StudentSystem
{
    public class CourseMaterial
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
