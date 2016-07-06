namespace Infestation
{
    internal class Queen : Parasite
    {
        public const int QueenPower = 1;
        public const int QueenAggression = 1;
        public const int QueenHealth = 30;

        public Queen(string id)
            : this(id, UnitClassification.Psionic, Queen.QueenHealth, Queen.QueenPower, Queen.QueenAggression)
        {
        }

        protected Queen(string id, UnitClassification unitClassification, int health, int power, int aggression)
            : base(id, unitClassification, health, power, aggression)
        {
        }
    }
}
