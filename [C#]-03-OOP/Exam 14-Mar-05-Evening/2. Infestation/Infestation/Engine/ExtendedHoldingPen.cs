namespace Infestation
{
    internal class ExtendedHoldingPen : HoldingPen
    {
        /// <summary>
        /// commandWords: supplement SupplementType targetUnitId
        /// </summary>
        /// <param name="commandWords"></param>
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unitToGetSupplement = GetUnit(commandWords[2]);

            if (unitToGetSupplement != null)
            {
                switch (commandWords[1])
                {
                    case "AggressionCatalyst":
                        unitToGetSupplement.AddSupplement(new AggressionCatalyst());
                        break;
                    case "HealthCatalyst":
                        unitToGetSupplement.AddSupplement(new HealthCatalyst());
                        break;
                    case "PowerCatalyst":
                        unitToGetSupplement.AddSupplement(new PowerCatalyst());
                        break;
                    case "Weapon":
                        unitToGetSupplement.AddSupplement(new Weapon());
                        break;
                    case "InfestationSpores":
                        // do nothing 
                        break;
                    case "WeaponrySkill":
                        // do nothing 
                        break;
                    case "AggressionInhibitor":
                        unitToGetSupplement.AddSupplement(new AggressionCatalyst());
                        break;
                    case "HealthInhibitor":
                        unitToGetSupplement.AddSupplement(new HealthCatalyst());
                        break;
                    case "PowerInhibitor":
                        unitToGetSupplement.AddSupplement(new PowerCatalyst());
                        break;
                    default:
                        break;
                }
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = base.GetUnit(interaction.TargetUnit);

                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    base.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    base.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    base.InsertUnit(queen);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    base.InsertUnit(tank);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }
    }
}
