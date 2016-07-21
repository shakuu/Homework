namespace School.Contracts
{
    using System.Collections.Generic;

    interface IStudent : IName, IIdentifiable
    {
        ICollection<ICourse> Courses { get; }

        bool SignUpForCourse(ICourse course);

        bool SignOutOfCourse(ICourse course);
    }
}
