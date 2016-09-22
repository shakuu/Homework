using System;
using System.Collections.Generic;
using System.Linq;

using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Directions.Contracts;

namespace MatrixPath.Logic.Directions
{
    public class BasicPathDirectionSequence : IDirectionSequence
    {
        private IEnumerable<IMovementDirection> directions;
        private IEnumerator<IMovementDirection> directionsEnumerator;
        private int sequenceLength = -1;

        public BasicPathDirectionSequence(Func<int, int, IMovementDirection> createDirection)
        {
            if (createDirection == null)
            {
                throw new ArgumentNullException("createDirection");
            }

            this.directions = this.GenerateSequence(createDirection);
            this.directionsEnumerator = this.directions.GetEnumerator();
        }

        public int DirectionSequenceLength
        {
            get
            {
                if (this.sequenceLength < 0)
                {
                    this.sequenceLength = this.directions.Count();
                }

                return this.sequenceLength;
            }
        }

        public IMovementDirection GetNextDirection()
        {
            if (!this.directionsEnumerator.MoveNext())
            {
                this.directionsEnumerator.Reset();
                this.directionsEnumerator.MoveNext();
            }

            var nextDirection = this.directionsEnumerator.Current;
            var clonedNextDirection = nextDirection.Clone();
            return clonedNextDirection;
        }

        private IEnumerable<IMovementDirection> GenerateSequence(Func<int, int, IMovementDirection> createDirection)
        {
            var directions = new LinkedList<IMovementDirection>();

            for (int col = 1; col > -1; col--)
            {
                var newDirection = createDirection(1, col);
                directions.AddLast(newDirection);
            }

            var directionLeft = createDirection(0, -1);
            directions.AddLast(directionLeft);

            for (int col = -1; col <= 1; col++)
            {
                var newDirection = createDirection(-1, col);
                directions.AddLast(newDirection);
            }

            var directionRight = createDirection(0, 1);
            directions.AddLast(directionRight);

            return directions;
        }
    }
}
