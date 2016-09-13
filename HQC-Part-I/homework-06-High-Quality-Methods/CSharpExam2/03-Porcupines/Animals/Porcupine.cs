using _03_Porcupines.Animals.Contracts;
using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;

namespace _03_Porcupines.Animals
{
    public class Porcupine : Animal, IPorcupine
    {
        public Porcupine(IPosition position)
            : base(position, MovementType.Crawl)
        {
        }
    }
}
