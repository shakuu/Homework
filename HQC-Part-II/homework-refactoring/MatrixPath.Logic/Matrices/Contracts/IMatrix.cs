using MatrixPath.Logic.Directions.Contracts;
using MatrixPath.Logic.Values.Contracts;

namespace MatrixPath.Logic.Matrices.Contracts
{
    public interface IMatrix
    {
        string Populate(IDirectionSequence directionsInstructions, ICellValueSequence values);
    }
}
