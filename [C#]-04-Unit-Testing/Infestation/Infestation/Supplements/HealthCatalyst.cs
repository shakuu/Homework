namespace Infestation
{
    internal class HealthCatalyst : ISupplement
    {
        private int powerEffect = 0;
        private int healthEffect = 3;
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

        public void ReactTo(ISupplement otherSupplement)
        {
            // TODO: ( possibly )
        }
    }
}
