using _03_Porcupines.Engine.Contracts;

namespace _03_Porcupines.Forests.Contracts
{
    public interface IForest
    {
        IPosition EvaluateMovement(IPosition startPosition, IMovement movement, out int pointsCollected);
    }
}
