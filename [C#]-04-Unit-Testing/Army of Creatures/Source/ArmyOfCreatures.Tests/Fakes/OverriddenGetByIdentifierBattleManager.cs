namespace ArmyOfCreatures.Tests.Fakes
{
    using System.Collections.Generic;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Tests.Fakes;

    public class OverriddenGetByIdentifierBattleManager : BattleManager
    {
        private int counter;
        private readonly IList<ICreaturesInBattle> creatures;

        public OverriddenGetByIdentifierBattleManager(
            ICreaturesFactory creaturesFactory,
            ILogger logger,
            ICreaturesInBattle attacker,
            ICreaturesInBattle defender)
            : base(creaturesFactory, logger)
        {
            this.counter = -1;
            this.creatures = new List<ICreaturesInBattle>()
            {
                attacker,
                defender
            };
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            counter++;
            return creatures[counter];
        }
    }
}
