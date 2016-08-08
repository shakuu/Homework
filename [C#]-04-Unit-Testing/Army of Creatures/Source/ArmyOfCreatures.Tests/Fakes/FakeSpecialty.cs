namespace ArmyOfCreatures.Tests.Fakes
{
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class FakeSpecialty : Specialty
    {
        private bool ApplyWhenAttackingIsCalled = false;
        private bool ApplyWhenDefendingIsCalled = false;
        private bool ApplyAfterDefendingIsCalled = false;
        private bool ChangeDamageWhenAttackingIsCalled = false;
        private bool ApplyOnSkipIsCalled = false;

        public bool MethodsAccessedWhenSkipAreCalled
        {
            get
            {
                var result = this.ApplyOnSkipIsCalled;
                return result;
            }
        }

        public bool MethodsAccessedWhenDealDamageAreCalled
        {
            get
            {
                var result = this.ChangeDamageWhenAttackingIsCalled;
                return result;
            }
        }

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

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            this.ChangeDamageWhenAttackingIsCalled = true;
            return currentDamage;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            this.ApplyOnSkipIsCalled = true;
        }
    }
}
