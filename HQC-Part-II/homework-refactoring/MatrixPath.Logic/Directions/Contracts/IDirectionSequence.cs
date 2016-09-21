using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Directions.Contracts
{
    public interface IDirectionSequence
    {
        int DirectionSequenceLength { get; }

        IMovementDirection GetNextDirection();
    }
}
