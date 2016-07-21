namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ISchool : INameable
    {
        ICollection<IStudent> Students { get; }

        ICollection<ICourse> Courses { get; }

        int GenerateUniqueStudentID();
    }
}
