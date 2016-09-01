using System;
using System.Collections.Generic;

using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Forests.Contracts;
using _03_Porcupines.Forests.Enums;

namespace _03_Porcupines.Forests
{
    public class JaggedForest : IForest
    {
        private IList<IList<IForestCell>> forest;

        public JaggedForest(int rowsCount, int baseColumnsCount, IForestCellFactory forestCellFactory)
        {
            this.forest = this.BuildTheForest(rowsCount, baseColumnsCount);
            this.forest = this.FillTheForest(this.forest, ForestCellContentType.Points, forestCellFactory);
        }

        public int CollectPoints(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void SetContentAtPosition(IPosition position, ForestCellContentType contentType)
        {
            if (position == null)
            {
                throw new ArgumentException("position");
            }

            this.forest[position.Row][position.Column].ContentType = contentType;
        }

        public IPosition EvaluateMovement(IPosition startPosition, IMovement movement)
        {
            var newPosition = startPosition.Clone();
            switch (movement.MovementType)
            {
                case Animals.Enums.MovementType.Jump:
                    newPosition = this.HandleJumpMovement(newPosition, movement.Delta.Clone());
                    this.SetContentAtPosition(newPosition, ForestCellContentType.Rabbit);
                    break;
                case Animals.Enums.MovementType.Crawl:
                    newPosition = this.HandleCrawlMovement(newPosition, movement.Delta.Clone());
                    this.SetContentAtPosition(newPosition, ForestCellContentType.Porcupine);
                    break;
                default:
                    throw new ArgumentException("movement.MovementType");
            }

            return newPosition;
        }

        private IPosition HandleJumpMovement(IPosition startPosition, IPosition delta)
        {
            throw new NotImplementedException();
        }

        private IPosition HandleCrawlMovement(IPosition currentPosition, IPosition delta)
        {
            var movesCount = this.GetMovesCount(delta);
            delta = this.AdjustDeltaForCrawling(delta, movesCount);
            for (int move = 0; move < movesCount; move++)
            {
                var nextPosition = currentPosition.Add(delta);
                currentPosition = this.ValidateNextPositionWithinForestLimit(nextPosition.Clone());
                if (this.forest[currentPosition.Row][currentPosition.Column].ContentType != ForestCellContentType.Points)
                {
                    currentPosition.Subtract(delta);
                    currentPosition = this.ValidateNextPositionWithinForestLimit(currentPosition);
                    break;
                }
            }

            return currentPosition;
        }

        private IPosition ValidateNextPositionWithinForestLimit(IPosition nextPosition)
        {
            while (nextPosition.Row < 0)
            {
                nextPosition.Row += this.forest.Count;
            }

            while (this.forest.Count <= nextPosition.Row)
            {
                nextPosition.Row %= this.forest.Count;
            }

            var forestRow = this.forest[nextPosition.Row];
            while (nextPosition.Column < 0)
            {
                nextPosition.Column += forestRow.Count;
            }

            while (forestRow.Count <= nextPosition.Column)
            {
                nextPosition.Column %= forestRow.Count;
            }

            return nextPosition;
        }

        private IPosition AdjustDeltaForCrawling(IPosition delta, int movesCount)
        {
            var newDelta = delta.Clone();
            newDelta.Row /= movesCount;
            newDelta.Column /= movesCount;

            return newDelta;
        }

        private int GetMovesCount(IPosition delta)
        {
            var movesCount = 0;
            if (delta.Row != 0)
            {
                movesCount = Math.Abs(delta.Row);
            }
            else
            {
                movesCount = Math.Abs(delta.Column);
            }

            return movesCount;
        }

        private IList<IList<IForestCell>> BuildTheForest(int rowsCount, int baseColumnsCount)
        {
            var forestColumnsMultiplier = 1;
            var forest = new IForestCell[rowsCount][];
            for (int row = 0; row < rowsCount / 2; row++)
            {
                var colsToAdd = forestColumnsMultiplier * baseColumnsCount;
                forestColumnsMultiplier++;

                forest[row] = new IForestCell[colsToAdd];
                forest[rowsCount - 1 - row] = new IForestCell[colsToAdd];
            }

            return forest;
        }

        private IList<IList<IForestCell>> FillTheForest(
            IList<IList<IForestCell>> forest,
            ForestCellContentType forestCellContent,
            IForestCellFactory forestCellFactory)
        {
            for (int row = 0; row < forest.Count; row++)
            {
                for (int column = 0; column < forest[row].Count; column++)
                {
                    var pointsValue = this.CalculatePointsValue(row, column);
                    var newForestCell = forestCellFactory.CreateForestCell(forestCellContent, pointsValue);
                    forest[row][column] = newForestCell;
                }
            }

            return forest;
        }

        private int CalculatePointsValue(int row, int column)
        {
            var rowValue = row + 1;
            var columnValue = column + 1;
            var cellValue = rowValue * columnValue;

            return cellValue;
        }
    }
}
