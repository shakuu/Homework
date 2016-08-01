namespace ArmyOfCreatures.Extended
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    internal class ExtendedBattleManager : BattleManager
    {
        private const int ThirdArmyCreaturesIdentifier = 3;

        private readonly ICollection<ICreaturesInBattle> thirddArmyCreatures;

        public ExtendedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.thirddArmyCreatures = new List<ICreaturesInBattle>();
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            try
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
            }
            catch (ArgumentException)
            {
                if (creatureIdentifier.ArmyNumber == ExtendedBattleManager.ThirdArmyCreaturesIdentifier)
                {
                    this.thirddArmyCreatures.Add(creaturesInBattle);
                }
                else
                {
                    throw;
                }
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            try
            {
                return base.GetByIdentifier(identifier);
            }
            catch (ArgumentException)
            {
                if (identifier.ArmyNumber == ExtendedBattleManager.ThirdArmyCreaturesIdentifier)
                {
                    return this.thirddArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
