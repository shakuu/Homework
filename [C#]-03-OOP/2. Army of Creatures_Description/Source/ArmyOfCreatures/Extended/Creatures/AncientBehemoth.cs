namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int AttackStat = 19;
        private const int DefenseStat = 19;
        private const int HealthPointsStat = 300;
        private const decimal DamageStat = (decimal)40;

        public AncientBehemoth()
            : base(AttackStat, DefenseStat, HealthPointsStat, DamageStat)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}