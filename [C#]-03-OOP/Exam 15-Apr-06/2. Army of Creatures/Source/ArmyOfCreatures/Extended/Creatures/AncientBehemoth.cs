namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    /// <summary>
    /// Add class AncientBehemoth. The AncientBehemoth is a creature with
    /// attack 19, defense 19, damage 40, health points 300 
    /// and has the following specialties:
    ///   ReduceEnemyDefenseByPercentage specialty with 80% damage reduction
    ///   DoubleDefenseWhenDefending specialty for 5 rounds
    /// Hint: The class AncientBehemoth is similar to Behemoth creature class.
    /// </summary>
    internal class AncientBehemoth : Creature
    {
        private const int InitialAttack = 19;
        private const int InitialDefense = 19;
        private const int InitialHealthPoints = 300;
        private const decimal InitialDamage = 40m;

        internal AncientBehemoth()
            : base(AncientBehemoth.InitialAttack, AncientBehemoth.InitialDefense, AncientBehemoth.InitialHealthPoints, AncientBehemoth.InitialDefense)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
