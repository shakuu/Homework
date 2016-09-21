using MatrixPath.Logic.Cells.Abstract;
using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Cells
{
    public class MovementDelta : DualPlaneCoordinatesContainer, IMovementDirection
    {
        public MovementDelta(int deltaRow, int deltaCol)
            : base(deltaRow, deltaCol)
        {
            this.DeltaRow = deltaRow;
            this.DeltaCol = deltaCol;
        }

        public int DeltaRow
        {
            get
            {
                return base.Row;
            }

            private set
            {
                base.Row = value;
            }
        }

        public int DeltaCol
        {
            get
            {
                return base.Col;
            }

            private set
            {
                base.Col = value;
            }
        }

        public IMovementDirection Clone()
        {
            var clone = new MovementDelta(this.DeltaRow, this.DeltaCol);
            return clone;
        }
    }
}
