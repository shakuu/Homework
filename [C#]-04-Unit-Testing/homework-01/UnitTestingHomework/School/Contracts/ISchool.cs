namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ISchool : IName
    {
        ICollection<ICourse> Courses { get; }

        int AssignStudentID();
    }
}
