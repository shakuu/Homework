using System;
using System.Collections.Generic;

using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Directions.Contracts;

namespace MatrixPath.Logic.Directions
{
    public class BasicPathDirectionSequence : IDirectionSequence
    {
        private IEnumerable<IMovementDirection> directions;

        public BasicPathDirectionSequence(Func<int, int, IMovementDirection> createDirection)
        {
            if (createDirection == null)
            {
                throw new ArgumentNullException("directionInstantiator");
            }

            this.directions = this.GenerateSequence(createDirection);
        }

        public IMovementDirection GetNextDirection()
        {
            var nextDirection = (IMovementDirection)this.GetNext();
            return nextDirection;
        }

        private IEnumerator<IMovementDirection> GetNext()
        {
            var directionsEnumerator = this.directions.GetEnumerator();
            while (true)
            {
                if (!directionsEnumerator.MoveNext())
                {
                    directionsEnumerator.Reset();
                    directionsEnumerator.MoveNext();
                }

                yield return directionsEnumerator.Current;
            }
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
