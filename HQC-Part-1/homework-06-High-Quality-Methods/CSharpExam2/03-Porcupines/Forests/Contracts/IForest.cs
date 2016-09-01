using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Forests.Enums;

namespace _03_Porcupines.Forests.Contracts
{
    public interface IForest
    {
        IPosition EvaluateMovement(IPosition startPosition, IMovement movement);

        int CollectPoints(int row, int column);

        void SetContentAtPosition(IPosition position, ForestCellContentType contentType);
    }
}
