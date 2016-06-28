namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        private const int AttackStat = 8;
        private const int DefenseStat = 8;
        private const int HealthPointsStat = 25;
        private const decimal DamageStat = (decimal)4.5;

        public Griffin() 
            : base(AttackStat, DefenseStat, HealthPointsStat, DamageStat)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
