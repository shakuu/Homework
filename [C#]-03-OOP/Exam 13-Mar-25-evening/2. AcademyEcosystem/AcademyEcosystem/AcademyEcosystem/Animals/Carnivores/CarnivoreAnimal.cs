
namespace AcademyEcosystem
{
    using System;

    public abstract class CarnivoreAnimal : Animal, ICarnivore
    {
        protected const int CouldNotEatMeat = 0;

        public CarnivoreAnimal(string name, Point location, int size)
            : base(name, location, size)
        {
        }

        protected bool CanEathSleepingOfAnySize { get; private set; }

        protected virtual int PreyMaximumSize
        {
            get
            {
                return this.Size;
            }
        }

        protected abstract int GetMaximumSizeOfPrey(bool preyIsSleeping);

        public virtual int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException();
            }

            if (animal.Size > this.GetMaximumSizeOfPrey(animal.State == AnimalState.Sleeping))
            {
                throw new ArgumentException();
            }

            var quantityOfMeatEaten = animal.GetMeatFromKillQuantity();
            return quantityOfMeatEaten;
        }
    }
}
