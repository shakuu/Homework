namespace Infestation
{
    internal class Weapon : ISupplement
    {
        private const int PowerBonusWithWeaponrySkill = 10;
        private const int AggressionBonusWithWeaponrySkill = 3;

        private int powerEffect = 0;
        private int healthEffect = 0;
        private int aggressionEffect = 0;

        public int AggressionEffect
        {
            get
            {
                return this.aggressionEffect;
            }
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
        }

        public int PowerEffect
        {
            get
            {
                return this.powerEffect;
            }
        }

        /// <summary>
        /// Reacts to WeaponrySkill by enabling Weapon effects
        /// </summary>
        /// <param name="otherSupplement"></param>
        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.powerEffect = Weapon.PowerBonusWithWeaponrySkill;
                this.aggressionEffect = AggressionBonusWithWeaponrySkill;
            }
        }
    }
}
