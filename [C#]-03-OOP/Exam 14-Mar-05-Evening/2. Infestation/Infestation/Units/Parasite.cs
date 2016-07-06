namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Parasite : Unit
    {
        public const int ParasitePower = 1;
        public const int ParasiteAggression = 1;
        public const int ParasiteHealth = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.ParasiteHealth, Parasite.ParasitePower, Parasite.ParasiteAggression)
        {
        }

        protected Parasite(string id, UnitClassification unitClassification, int health, int power, int aggression)
            : base (id, unitClassification, health, power, aggression)
        {

        }

        /// <summary>
        /// Infest on viable target OR passive
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> infestableUnits = units.Where((unit) => this.CanInfestUnit(unit));

            UnitInfo optimalInfestableUnit = GetOptimalInfestableUnit(infestableUnits);

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        /// <summary>
        /// the Parasite picks the one with the least Health
        /// </summary>
        /// <param name="attackableUnits"></param>
        /// <returns></returns>
        protected UnitInfo GetOptimalInfestableUnit(IEnumerable<UnitInfo> infestableUnits)
        {
            UnitInfo optimalInfestableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            optimalInfestableUnit = infestableUnits.OrderBy(unit => unit.Health).First();

            return optimalInfestableUnit;
        }

        /// <summary>
        /// Return only units which meet the requirements in InfestationRequirements class.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        protected bool CanInfestUnit(UnitInfo unit)
        {
            bool infestUnit = false;
            if (this.Id != unit.Id)
            {
                if (this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification))
                {
                    infestUnit = true;
                }
            }
            return infestUnit;
        }
    }
}
