namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Battles;

    /// <summary>
    /// Add class DoubleDamage. The DoubleDamage is a specialty that doubles the
    /// current damage during battle.
    /// 
    /// Override the default ToString() implementation to return the name of the specialty
    /// with the number of rounds remaning in parentesis. Example: “DoubleDamage(7)”
    /// 
    /// Hint: The class Hate (specialty) also changes the damage during the battle.
    /// Hint: The class DoubleDefenseWhenDefending also has fixed rounds of effectiveness.
    /// </summary>
    internal class DoubleDamage : ExtendedSpecialty
    {
        private const int MinimumTurns = 1;
        private const int MaximumTurns = 10;

        //private int rounds;

        /// <summary>
        /// The DoubleDamage class should have only one constructor that accepts one argument –
        /// the number of rounds for the specialty to has effect.After these rounds(attacks) 
        /// the effect of this specialty stops.
        /// 
        /// The number of rounds in the constructor should be greater than 0
        /// The number of rounds in the constructor should be less than or equal to 10
        /// 
        /// </summary>
        /// <param name="rounds"></param>
        internal DoubleDamage(int rounds)
            : base(rounds, DoubleDamage.MinimumTurns, DoubleDamage.MaximumTurns)
        {
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            base.CheckInputCreatures(attackerWithSpecialty, "attackerWithSpecialty");
            base.CheckInputCreatures(defender, "defender");

            var hasAvailableRounds = base.DecrementRoundsCounter();
            return hasAvailableRounds
                ? currentDamage * 2
                : currentDamage;
        }
    }
}
