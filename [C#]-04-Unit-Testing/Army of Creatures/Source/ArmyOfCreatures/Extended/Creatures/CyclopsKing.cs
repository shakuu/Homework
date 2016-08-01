namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Extended.Specialties;

    /// <summary>
    /// Add class CyclopsKing. The CyclopsKing is a creature with
    /// attack 17, defense 13, damage 18, health points 70 
    /// 
    /// and the following specialties:
    /// AddAttackWhenSkip with 3 attack points for each skip action.
    /// DoubleAttackWhenAttacking for 4 rounds
    /// DoubleDamage for 1 round
    /// </summary>
    internal class CyclopsKing : Creature
    {
        private const int InitialAttack = 17;
        private const int InitialDefense = 13;
        private const int InitialHealthPoints = 70;
        private const decimal InitialDamage = 18m;

        private const int SpecialtyAddAttackWhenSkip = 3;
        private const int SpecialtyDoubleAttackWhenAttacking = 4;
        private const int SpecialtyDoubleDamage = 1;

        internal CyclopsKing()
            : base(CyclopsKing.InitialAttack, CyclopsKing.InitialDefense, CyclopsKing.InitialHealthPoints, CyclopsKing.InitialDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKing.SpecialtyAddAttackWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKing.SpecialtyDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(CyclopsKing.SpecialtyDoubleDamage));
        }
    }
}
