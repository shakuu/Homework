namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;

    using Logic.Battles;
    using Logic.Specialties;

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
    internal class DoubleDamage : DoubleDefenseWhenDefending
    {
        private const int MinimumTurns = 1;
        private const int MaximumTurns = 10;

        private int rounds;

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
            : base(rounds)
        {
            Validator.CheckValidRange(
                rounds, DoubleDamage.MinimumTurns, DoubleDamage.MaximumTurns);

            this.rounds = rounds;
        }

        /// <summary>
        /// Do NOT apply the original effect.
        /// </summary>
        /// <param name="defenderWithSpecialty"></param>
        /// <param name="attacker"></param>
        public override void ApplyWhenDefending(
            ICreaturesInBattle defenderWithSpecialty,
            ICreaturesInBattle attacker)
        {
            // Do nothing.
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            Validator.CheckCreaturesForNull(
                attackerWithSpecialty, "attackerWithSpecialty",
                defender, "defender");

            // TODO: Method
            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * 2;
        }
    }
}
