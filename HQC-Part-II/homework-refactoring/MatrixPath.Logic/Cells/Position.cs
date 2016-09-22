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

        public IPosition MoveTo(int row, int col)
        {
            var movedTo = new Position(row, col);
            return movedTo;
        }

        public IPosition Clone()
        {
            var clonedPosition = new Position(this.Row, this.Col);
            return clonedPosition;
        }
    }
}
