namespace AcademyEcosystem
{
    /// <summary>
    /// Implement a command to create a Zombie. 
    /// The Zombie should be an animal and should not be able to eat.
    /// </summary>
    public class Zombie : Animal
    {
        private const int InitialSize = 0;

        private const int MeatAmountWhenEaten = 10;

        public Zombie(string name, Point location)
            : base(name, location, Zombie.InitialSize)
        {
        }

        /// <summary>
        /// When a carnivore (of the so-far existing) tries to eat a Zombie, 
        /// it should always succeed and receive 10 meat from the Zombie.
        /// However, the Zombie should never die.         
        /// </summary>
        /// <returns>A constant amount</returns>
        public override int GetMeatFromKillQuantity()
        {
            return Zombie.MeatAmountWhenEaten;
        }
    }
}
