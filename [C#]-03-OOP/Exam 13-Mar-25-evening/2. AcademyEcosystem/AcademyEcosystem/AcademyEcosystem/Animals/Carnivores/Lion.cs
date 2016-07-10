
namespace AcademyEcosystem
{
    using System;
    
    /// <summary>
    /// Implement a command to create a Lion.
    /// The Lion should be an animal and should have a Size of 6.
    /// </summary>
    public class Lion : CarnivoreAnimal
    {
        private const int InitialSize = 6;

        private const int GrowWithAmount = 1;

        public Lion(string name, Point location)
            : base(name, location, Lion.InitialSize)
        {
        }

        protected override int GetMaximumSizeOfPrey(bool preyIsSleeping)
        {
            return this.Size * 2;
        }

        /// <summary>
        /// The Lion should be able to eat any animal, 
        /// which is at most twice larger than him (inclusive). 
        /// Also, the Lion should grow by 1 with each animal it eats.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public override int TryEatAnimal(Animal animal)
        {
            var quantitiyEaten = CarnivoreAnimal.CouldNotEatMeat;

            try
            {
                quantitiyEaten = base.TryEatAnimal(animal);
                this.GrowWhenEating(Lion.GrowWithAmount);
            }
            catch (ArgumentException)
            {
                return CarnivoreAnimal.CouldNotEatMeat;
            }

            return quantitiyEaten;
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
