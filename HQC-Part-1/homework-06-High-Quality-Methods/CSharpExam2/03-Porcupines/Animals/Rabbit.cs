using _03_Porcupines.Animals.Contracts;
using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;

namespace _03_Porcupines.Animals
{
    public class Rabbit : Animal, IRabbit
    {
        public Rabbit(IPosition position)
            : base(position, MovementType.Jump)
        {
        }
    }
}
