namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse : INameable
    {
        ICollection<IStudent> Students { get; }

        bool AddStudentToCourse(IStudent student);

        bool RemoveStudentFromCourse(IStudent student);
    }
}