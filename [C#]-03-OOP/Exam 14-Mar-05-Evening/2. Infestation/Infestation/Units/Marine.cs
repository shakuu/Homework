namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        /// <summary>
        /// The target’s Power is less than or equal to the Marine’s Aggression
        /// If there is more than one such target, the marine picks the one with the highest Health
        /// </summary>
        /// <param name="attackableUnits"></param>
        /// <returns>UnitInfo optimaAttackableUnit</returns>
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            // TODO: Verify
            optimalAttackableUnit =
                attackableUnits
                    .Where(unit => unit.Power <= this.Aggression)
                    .OrderByDescending(unit => unit.Health)
                    .FirstOrDefault();
            
            return optimalAttackableUnit;
        }
    }
}
