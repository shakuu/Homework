namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;
    using Specialties;

    class CyclopsKing : Creature
    {
        private const int AttackStat = 17;
        private const int DefenseStat = 13;
        private const int HealthPointsStat = 70;
        private const decimal DamageStat = (decimal)18;

        public CyclopsKing() 
            : base(AttackStat, DefenseStat, HealthPointsStat, DamageStat)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
