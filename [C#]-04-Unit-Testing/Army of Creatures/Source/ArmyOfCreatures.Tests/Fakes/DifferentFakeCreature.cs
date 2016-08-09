namespace ArmyOfCreatures.Tests.Fakes
{
    public class DifferentFakeCreature : FakeCreature
    {
        public DifferentFakeCreature()
        {
            this.AddSpecialty(new FakeSpecialty());
            this.AddSpecialty(new FakeSpecialty());
            this.AddSpecialty(new FakeSpecialty());
            this.AddSpecialty(new FakeSpecialty());
            this.AddSpecialty(new FakeSpecialty());
        }
    }
}
