namespace ArmyOfCreatures.Extended.Specialties
{
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    /// <summary>
    /// Add class AddAttackWhenSkip.
    /// The AddAttackWhenSkip is a specialty that adds attack points to
    /// the permanent attack points of the creature and is applied when
    /// creature skips its turn.
    /// 
    /// The class should have only one constructor which accepts
    /// integer argument(between 1 and 10, inclusive) – 
    /// the value to add to the permanent attack of the 
    /// creature during skip action in battle.
    /// 
    /// Override the default ToString() implementation 
    /// to return the name of the specialty with the number of
    /// attack to add in parentesis.Example: “AddAttackWhenSkip(3)”
    /// 
    /// Hint: The class AddAttackWhenSkip is similar to AddDefenseWhenSkip.
    /// </summary>
    internal class AddAttackWhenSkip : ExtendedSpecialty
    {
        private const int MinimumAttackToAdd = 1;
        private const int MaximumAttackToAdd = 10;

        internal AddAttackWhenSkip(int attackToAdd)
            : base(attackToAdd, AddAttackWhenSkip.MinimumAttackToAdd, AddAttackWhenSkip.MaximumAttackToAdd)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            base.CheckInputCreatures(skipCreature, "skipCreature");
            skipCreature.PermanentAttack += this.Specialty;
        }
    }
}
