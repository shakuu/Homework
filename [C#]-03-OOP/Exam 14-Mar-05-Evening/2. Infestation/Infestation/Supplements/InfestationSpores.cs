namespace Infestation
{
    internal class InfestationSpores : ISupplement
    {
        private const int ReactToInfestationSporesPowerEffect = 0;
        private const int ReactToInfestationSporesAggressionEffect = 0;

        private int powerEffect = -1;
        private int healthEffect = 0;
        private int aggressionEffect = 20;

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
        /// React to other InfestationSpored by setting bonuses to 0
        /// </summary>
        /// <param name="otherSupplement"></param>
        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.powerEffect = InfestationSpores.ReactToInfestationSporesPowerEffect;
                this.aggressionEffect = InfestationSpores.ReactToInfestationSporesAggressionEffect;
            }
        }
    }
}
