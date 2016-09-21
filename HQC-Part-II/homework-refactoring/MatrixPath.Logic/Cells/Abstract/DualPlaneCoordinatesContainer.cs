using MatrixPath.Logic.Cells.Contracts;

namespace MatrixPath.Logic.Cells.Abstract
{
    public abstract class DualPlaneCoordinatesContainer : IDualPlaneCoordinatesContainer
    {
        private int row;
        private int col;

        protected DualPlaneCoordinatesContainer(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public virtual int Row { get; protected set; }

        public virtual int Col { get; protected set; }
    }
}
