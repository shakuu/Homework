namespace ArmyOfCreatures.Tests.Fakes
{
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class FakeSpecialty : Specialty
    {
        private bool ApplyWhenAttackingIsCalled = false;
        private bool ApplyWhenDefendingIsCalled = false;
        private bool ApplyAfterDefendingIsCalled = false;

        public bool MethodsAccessedAsAttackerAreCalled
        {
            get
            {
                var result = this.ApplyWhenAttackingIsCalled;
                return result;
            }
        }

        public bool MethodsAccessedAsDefenderAreCalled
        {
            get
            {
                var result = this.ApplyWhenDefendingIsCalled && this.ApplyAfterDefendingIsCalled;
                return result;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            this.ApplyWhenAttackingIsCalled = true;
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
            this.ApplyWhenDefendingIsCalled = true;
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
            this.ApplyAfterDefendingIsCalled = true;
        }
    }
}
