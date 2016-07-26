namespace Cars.Contracts
{
    public interface ICar
    {
        int Id { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
    }
}