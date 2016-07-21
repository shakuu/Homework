namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse : IName
    {
        ICollection<IStudent> Students { get; }

        bool AddStudentToCourse(IStudent student);

        bool RemoveStudentFromCourse(IStudent student);
    }
}