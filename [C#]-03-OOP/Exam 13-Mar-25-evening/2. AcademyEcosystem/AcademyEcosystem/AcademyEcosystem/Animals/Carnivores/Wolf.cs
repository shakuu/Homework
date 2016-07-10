namespace AcademyEcosystem
{
    /// <summary>
    /// The Wolf should be able to eat any animal
    /// smaller than or as big as him, 
    /// or any animal which is sleeping.
    /// </summary>
    public class Wolf : Animal, ICarnivore
    {
        private const int InitialSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, Wolf.InitialSize)
        {
        }

        /// <summary>
        /// Note: The proper way to implement the TryEatAnimal method is
        /// to call the passed animal's GetMeatFromKillQuantity().
        /// The TryEatAnimal method must return the quantity of meat eaten.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                return 0;
            }

            var quantityOfMeatEaten = 0;

            if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
            {
                quantityOfMeatEaten = animal.GetMeatFromKillQuantity();
            }

            return quantityOfMeatEaten;
        }
    }
}
