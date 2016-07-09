namespace AcademyRPG
{
    using System.Collections.Generic;

    public class Giant : Character, IFighter, IGatherer
    {
        private const int AttackPointsDefault = 150;
        private const int DefensePointsDefault = 80;
        private const int HitPointsDefault = 200;
        private const int AttackPointsStoneGatheredBonus = 100;

        private int attackPoints;
        private int defensePoints;

        public Giant(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = Giant.HitPointsDefault;
            this.attackPoints = Giant.AttackPointsDefault;
            this.defensePoints = Giant.DefensePointsDefault;
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
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {

            if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints = Giant.AttackPointsDefault + Giant.AttackPointsStoneGatheredBonus;
                return true;
            }

            return false;
        }
    }
}
