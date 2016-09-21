using MatrixPath.Logic.Cells;
using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Utils
{
    public static class InstantiatingMethods
    {
        public static IMovementDirection CreateDirection(int deltaRow, int deltaCol)
        {
            var direction = new MovementDelta(deltaRow, deltaCol);
            return direction;
        }

        public static ICell CreateMatrixCell(int rowCoordinate, int colCoordiante, int cellValue = 0)
        {
            var cell = new MatrixCell(rowCoordinate, colCoordiante, cellValue);
            return cell;
        }
    }
}
