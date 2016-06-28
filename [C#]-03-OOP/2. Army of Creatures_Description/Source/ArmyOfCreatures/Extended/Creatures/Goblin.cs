namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    public class Goblin : Creature
    {
        private const int AttackStat = 4;
        private const int DefenseStat = 2;
        private const int HealthPointsStat = 5;
        private const decimal DamageStat = (decimal)1.5;

        public Goblin() 
            : base(AttackStat, DefenseStat, HealthPointsStat, DamageStat)
        {
        }
    }
}
