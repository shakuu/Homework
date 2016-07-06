namespace Infestation
{
    internal class Queen : Parasite
    {
        public const int QueenPower = 1;
        public const int QueenAggression = 1;
        public const int QueenHealth = 30;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.QueenHealth, Queen.QueenPower, Queen.QueenAggression)
        {
        }
    }
}
