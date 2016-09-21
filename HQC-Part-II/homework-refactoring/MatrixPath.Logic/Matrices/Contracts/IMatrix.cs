using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Directions.Contracts;
using MatrixPath.Logic.Values.Contracts;

namespace MatrixPath.Logic.Matrices.Contracts
{
    public interface IMatrix
    {
        void Populate(IPosition startPosition, IDirectionSequence directionsInstructions, ICellValueSequence values);
    }
}
