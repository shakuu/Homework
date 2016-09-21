namespace MatrixPath.Logic.Cells.Contracts
{
    public interface IPosition : IDualPlaneCoordinatesContainer
    {
        IPosition MoveInDirection(IMovementDirection direction);
    }
}
