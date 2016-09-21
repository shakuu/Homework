using MatrixPath.Logic.Cells.Abstract;
using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Cells
{
    public class Position : DualPlaneCoordinatesContainer, IPosition
    {
        public Position(int row, int col)
            : base(row, col)
        {
        }

        public IPosition MoveInDirection(IMovementDirection direction)
        {
            var nextRow = this.Row + direction.DeltaRow;
            var nextCol = this.Col + direction.DeltaCol;
            var resultingPosition = new Position(nextRow, nextCol);

            return resultingPosition;
        }
    }
}
