using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;

namespace _03_Porcupines.Animals.Contracts
{
    public interface IAnimal
    {
        IPosition Position { get; set; }

        MovementType MovementType { get; }

        int PointsCollected { get; set; }
    }
}
