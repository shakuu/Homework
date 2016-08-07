namespace Infestation
{
    internal class AggressionCatalyst : ISupplement
    {
        private int powerEffect = 0;
        private int healthEffect = 0;
        private int aggressionEffect = 3;

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
