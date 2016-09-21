using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Directions.Contracts
{
    public interface IDirectionSequence
    {
        IMovementDirection GetNextDirection();

        int DirectionSequenceLength { get; }
    }
}
