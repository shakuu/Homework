namespace School.Contracts
{
    public interface IStudent : INameable, IIdentifiable
    {
        bool JoinCourse(ICourse course);

        bool LeaveCourse(ICourse course);
    }
}
