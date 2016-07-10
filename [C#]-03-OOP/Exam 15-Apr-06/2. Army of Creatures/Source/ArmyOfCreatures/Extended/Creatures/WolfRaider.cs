namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    /// <summary>
    /// Add class WolfRaider. The WolfRaider is a creature with 
    /// attack 8, defense 5, health points 10, damage 3.5 and:
    /// DoubleDamage specialty for 7 rounds
    /// </summary>
    class WolfRaider : Creature
    {
        private const int InitialAttack = 8;
        private const int InitialDefense = 5;
        private const int InitialHealthPoints = 10;
        private const decimal InitialDamage = 3.5m;

        internal WolfRaider()
            : base(WolfRaider.InitialAttack, WolfRaider.InitialDefense, WolfRaider.InitialHealthPoints, WolfRaider.InitialDamage)
        {
            this.AddSpecialty(new DoubleDamage(7));
        }
    }
}
