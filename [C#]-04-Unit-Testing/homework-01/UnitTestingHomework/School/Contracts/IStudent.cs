namespace School.Contracts
{
    public interface IStudent : IName, IIdentifiable
    {
        bool JoinCourse(ICourse course);

        bool LeaveCourse(ICourse course);
    }
}
