namespace MatrixPath.Logic.Cells.Contracts
{
    public interface IMovementDirection
    {
        int DeltaRow { get; }

        int DeltaCol { get; }

        IMovementDirection Clone();
    }
}
