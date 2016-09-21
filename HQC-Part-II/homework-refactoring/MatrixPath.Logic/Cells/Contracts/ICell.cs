namespace MatrixPath.Logic.Cells.Contracts
{
    public interface ICell : IDualPlaneCoordinatesContainer
    {
        int Value { get; set; }
    }
}
