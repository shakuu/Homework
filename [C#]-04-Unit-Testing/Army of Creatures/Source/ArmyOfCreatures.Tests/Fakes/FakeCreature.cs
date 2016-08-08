namespace ArmyOfCreatures.Tests.Fakes
{
    using ArmyOfCreatures.Logic.Creatures;

    public class FakeCreature : Creature
    {
        public const int FakeAttack = 5;
        public const int FakeDefense = 5;
        public const int FakeHealthPoints = 5;
        public const int FakeDamage = 5;

        public FakeCreature()
            : base(FakeCreature.FakeAttack,
                   FakeCreature.FakeDamage,
                   FakeCreature.FakeHealthPoints,
                   FakeCreature.FakeDamage)
        {
            this.AddSpecialty(new FakeSpecialty());
        }
    }
}
