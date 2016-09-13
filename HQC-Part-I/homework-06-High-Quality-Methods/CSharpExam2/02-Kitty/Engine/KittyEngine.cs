using System;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Results.Contracts;

namespace _02_Kitty.Engine
{
    public class KittyEngine : IEngine
    {
        private IPathGenerator pathGenerator;
        private IResultTracker resultTracker;
        private ISequenceGenerator jumpsSequenceGenerator;

        public KittyEngine(IPathGenerator pathGenerator, IResultTracker resultTracker, ISequenceGenerator jumpsSequenceGenerator)
        {
            if (pathGenerator == null)
            {
                throw new ArgumentNullException("pathGenerator");
            }

            if (jumpsSequenceGenerator == null)
            {
                throw new ArgumentNullException("jumpsSequenceGenerator");
            }

            if (resultTracker == null)
            {
                throw new ArgumentNullException("resultTracker");
            }

            this.resultTracker = resultTracker;
            this.jumpsSequenceGenerator = jumpsSequenceGenerator;
            this.pathGenerator = pathGenerator;
        }

        public string EvaluteSequenceOfJumps(string path, string sequence)
        {
            var pathCells = this.pathGenerator.CreatePath(path);
            var pathLength = pathCells.Count;

            var jumpsPositionsSequence = this.jumpsSequenceGenerator.GenerateSequenceOfPostions(sequence, pathLength);
            foreach (var jumpPosition in jumpsPositionsSequence)
            {
                var nextPathCell = pathCells[jumpPosition];
                var isDeadlocked = this.resultTracker.EvaluateCell(nextPathCell);
                if (isDeadlocked)
                {
                    break;
                }
            }

            var report = this.resultTracker.CreateReport();

            return report;
        }
    }
}
