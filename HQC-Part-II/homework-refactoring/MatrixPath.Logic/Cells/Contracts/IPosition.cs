using System;

namespace MatrixPath.Logic.Cells.Contracts
{
    public interface IPosition : IDualPlaneCoordinatesContainer
    {
        IPosition MoveInDirection(IMovementDirection direction);

        IPosition MoveTo(int row, int col);

        IPosition Clone();
    }
}
