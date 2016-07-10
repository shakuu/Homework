namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    /// <summary>
    /// Add class Goblin. 
    /// The Goblin is a creature with 
    /// attack 4, defence 2, health points 5 and damage 1.5 and has no specialties.
    /// </summary>
    internal class Goblin : Creature
    {
        private const int InitialAttack = 4;
        private const int InitialDefense = 2;
        private const int InitialHealthPoints = 5;
        private const decimal InitialDamage = 1.5m;

        internal Goblin() 
            : base(Goblin.InitialAttack, Goblin.InitialDefense, Goblin.InitialHealthPoints, Goblin.InitialDamage)
        {
        }
    }
}

