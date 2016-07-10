namespace AcademyEcosystem
{
    /// <summary>
    /// Implement a command to create a Boar.
    /// The Boar should be an animal and should have a Size of 4.
    /// </summary>
    public class Boar : Animal, IHerbivore, ICarnivore
    {
        private const int InitialSize = 4;

        private const int BiteSize = 2;

        private const int GrowWhenEatingPlantsWithAmount = 1;

        public Boar(string name, Point location)
            : base(name, location, Boar.InitialSize)
        {
        }

        /// <summary>
        /// The Boar should be able to eat any animal, 
        /// which is smaller than him or as big as him. 
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

            if (animal.Size <= this.Size)
            {
                quantityOfMeatEaten = animal.GetMeatFromKillQuantity();
            }

            return quantityOfMeatEaten;
        }

        /// <summary>
        /// The Boar should be able to eat from any plant.
        /// The Boar always has a bite size of 2.
        /// When eating from a plant, 
        /// the Boar increases its size by 1.
        /// </summary>
        /// <param name="plant"></param>
        /// <returns></returns>
        public int EatPlant(Plant plant)
        {
            if (plant == null)
            {
                return 0;
            }

            var quantityEaten = plant.GetEatenQuantity(Boar.BiteSize);

            this.GrowWhenEating(Boar.GrowWhenEatingPlantsWithAmount);

            return quantityEaten;
        }

        /// <summary>
        /// Increase Lion size with the passed amount
        /// </summary>
        /// <param name="increaseSizeWithAmount"></param>
        private void GrowWhenEating(int increaseSizeWithAmount)
        {
            this.Size += increaseSizeWithAmount;
        }
    }
}
