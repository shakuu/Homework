namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        private const int AttackStat = 8;
        private const int DefenseStat = 5;
        private const int HealthPointsStat = 10;
        private const decimal DamageStat = (decimal)3.5;

        public WolfRaider() 
            : base(AttackStat, DefenseStat, HealthPointsStat, DamageStat)
        {
            this.AddSpecialty(new DoubleDamage(7));
        }
    }
}
