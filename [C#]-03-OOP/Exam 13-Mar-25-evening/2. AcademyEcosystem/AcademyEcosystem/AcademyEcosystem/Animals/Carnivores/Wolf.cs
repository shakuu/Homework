namespace AcademyEcosystem
{
    using System;

    /// <summary>
    /// The Wolf should be able to eat any animal
    /// smaller than or as big as him, 
    /// or any animal which is sleeping.
    /// </summary>
    public class Wolf : CarnivoreAnimal
    {
        private const int InitialSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, Wolf.InitialSize)
        {
        }

        protected override int GetMaximumSizeOfPrey(bool preyIsSleeping)
        {
            var maximumPreySize = CarnivoreAnimal.CouldNotEatMeat;

            if (preyIsSleeping)
            {
                maximumPreySize = int.MaxValue;
            }
            else
            {
                maximumPreySize = this.Size;
            }

            return maximumPreySize;
        }

        /// <summary>
        /// Note: The proper way to implement the TryEatAnimal method is
        /// to call the passed animal's GetMeatFromKillQuantity().
        /// The TryEatAnimal method must return the quantity of meat eaten.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public override int TryEatAnimal(Animal animal)
        {
            var quantitiyEaten = CarnivoreAnimal.CouldNotEatMeat;

            try
            {
                quantitiyEaten = base.TryEatAnimal(animal);
            }
            catch (ArgumentException)
            {
                return CarnivoreAnimal.CouldNotEatMeat;
            }

            return quantitiyEaten;
        }
    }
}
