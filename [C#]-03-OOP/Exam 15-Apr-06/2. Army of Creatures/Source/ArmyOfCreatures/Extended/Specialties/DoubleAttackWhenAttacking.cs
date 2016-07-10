namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    /// <summary>
    /// Add class DoubleAttackWhenAttacking. 
    /// The DoubleAttackWhenAttacking is a specialty.
    /// It doubles the current attack when creature is attacking.
    /// The class should have only one constructor that accepts one argument – 
    /// the number of rounds for the specialty to has effect.
    /// After these rounds the effect of this specialty stops.
    /// 
    /// The number of rounds in the constructor should be greater than 0
    /// 
    /// Override the default ToString() implementation to return the name
    /// of the specialty with the number of rounds left in parentesis. 
    /// 
    /// Example: “DoubleAttackWhenAttacking(4)”
    /// </summary>
    internal class DoubleAttackWhenAttacking : DoubleDefenseWhenDefending
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds) 
            : base(rounds)
        {
            this.rounds = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (this.rounds <= 0)
            {
                return;
            }

            base.ApplyWhenDefending(attackerWithSpecialty, defender);
            attackerWithSpecialty.CurrentDefense /= 2;
            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }
    }
}
