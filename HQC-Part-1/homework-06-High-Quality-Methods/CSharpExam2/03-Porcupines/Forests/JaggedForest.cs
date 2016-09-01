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

        public IPosition EvaluateMovement(IPosition startPosition, IMovement movement, out int pointsCollected)
        {
            IPosition newPosition;
            switch (movement.MovementType)
            {
                case Animals.Enums.MovementType.Jump:
                    newPosition = this.HandleJumpMovement(startPosition, movement, out pointsCollected);
                    break;
                case Animals.Enums.MovementType.Crawl:
                    newPosition = this.HandleCrawlMovement(startPosition, movement, out pointsCollected);
                    break;
                default:
                    throw new ArgumentException("movement.MovementType");
            }

            return newPosition;
        }

        private IPosition HandleJumpMovement(IPosition startPosition, IMovement movement, out int pointsCollected)
        {
            throw new NotImplementedException();
        }

        private IPosition HandleCrawlMovement(IPosition startPosition, IMovement movement, out int pointsCollected)
        {
            throw new NotImplementedException();
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
