namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    /// <summary>
    /// Add class Griffin. The Griffin is a creature with 
    /// attack 8, defense 8, damage 4.5 and health points 25.
    /// 
    /// It also has the following specialties:
    /// DoubleDefenseWhenDefending for 5 rounds
    /// AddDefenseWhenSkip with 3 defense points
    /// Hate specialty to WolfRaider creatures
    /// Hint: The Angel, Archangel, Devil and ArchDevil creatures also have Hate specialty.
    /// </summary>
    internal class Griffin : Creature
    {
        private const int InitialAttack = 8;
        private const int InitialDefense = 8;
        private const int InitialHealthPoints = 25;
        private const decimal InitialDamage = 4.5m;

        internal Griffin()
            : base(Griffin.InitialAttack, Griffin.InitialDefense, Griffin.InitialHealthPoints, Griffin.InitialDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
