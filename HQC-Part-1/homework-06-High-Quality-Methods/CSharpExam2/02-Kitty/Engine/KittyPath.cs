using System;
using System.Collections.Generic;
using System.Linq;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Results.Contracts;

namespace _02_Kitty.Engine
{
    public class KittyPath : IPath
    {
        private int pathLength;
        private IList<IPathCell> pathCells;
        private ISequenceGenerator jumpsSequenceGenerator;

        public KittyPath(IList<IPathCell> pathCells, ISequenceGenerator jumpsSequenceGenerator)
        {
            if (pathCells == null)
            {
                throw new ArgumentNullException("pathCells");
            }

            if (jumpsSequenceGenerator == null)
            {
                throw new ArgumentNullException("jumpsSequenceGenerator");
            }

            this.jumpsSequenceGenerator = jumpsSequenceGenerator;
            this.pathCells = pathCells;
            this.pathLength = this.pathCells.Count;
        }

        public IResult EvaluteSequenceOfJumps(string sequence, IResult resultTracker)
        {
            var jumpsPositionsSequence = this.jumpsSequenceGenerator.GenerateSequenceOfPostions(sequence, this.pathLength);
            foreach (var jumpPosition in jumpsPositionsSequence)
            {
                var nextPathCell = this.pathCells[jumpPosition];
                var isDeadlocked = resultTracker.EvaluateCellContent(nextPathCell);
                if (isDeadlocked)
                {
                    break;
                }
            }

            return resultTracker;
        }
    }
}
