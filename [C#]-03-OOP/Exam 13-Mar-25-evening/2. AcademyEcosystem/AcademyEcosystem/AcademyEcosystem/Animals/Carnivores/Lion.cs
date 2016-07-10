namespace AcademyEcosystem
{
    /// <summary>
    /// Implement a command to create a Lion.
    /// The Lion should be an animal and should have a Size of 6.
    /// </summary>
    public class Lion : Animal, ICarnivore
    {
        private const int InitialSize = 6;

        private const int GrowWithAmount = 1;

        public Lion(string name, Point location)
            : base(name, location, Lion.InitialSize)
        {
        }

        /// <summary>
        /// The Lion should be able to eat any animal, 
        /// which is at most twice larger than him (inclusive). 
        /// Also, the Lion should grow by 1 with each animal it eats.
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

            if (animal.Size <= this.Size * 2)
            {
                quantityOfMeatEaten = animal.GetMeatFromKillQuantity();
                this.GrowWhenEating(Lion.GrowWithAmount);
            }

            return quantityOfMeatEaten;
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
