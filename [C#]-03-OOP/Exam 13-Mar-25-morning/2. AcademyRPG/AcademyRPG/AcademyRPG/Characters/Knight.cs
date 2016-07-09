namespace AcademyRPG
{
    using System.Collections.Generic;

    internal class Knight : Character, IFighter
    {
        private const int AttackPointsDefault = 100;
        private const int DefensePointsDefault = 100;
        private const int HitPointsDefault = 100;

        private int attackPoints;
        private int defensePoints;

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = Knight.HitPointsDefault;
            this.attackPoints = Knight.AttackPointsDefault;
            this.defensePoints = Knight.DefensePointsDefault;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0 && (availableTargets[i] as Character).Name != this.Name)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
