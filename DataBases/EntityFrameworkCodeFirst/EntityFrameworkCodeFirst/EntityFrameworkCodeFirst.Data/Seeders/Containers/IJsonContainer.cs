namespace EntityFrameworkCodeFirst.Data.Seeders.Containers
{
    public interface IJsonContainer
    {
        string SeededNamesJson { get; }

        string SeededCoursesJson { get; }
    }
}
