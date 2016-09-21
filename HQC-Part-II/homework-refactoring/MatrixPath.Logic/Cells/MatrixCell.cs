using MatrixPath.Logic.Cells.Abstract;
using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Cells
{
    public class MatrixCell : DualPlaneCoordinatesContainer, ICell
    {
        private int value;

        public MatrixCell(int rowCoordinate, int colCoordinate, int value)
            : base(rowCoordinate, colCoordinate)
        {
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
