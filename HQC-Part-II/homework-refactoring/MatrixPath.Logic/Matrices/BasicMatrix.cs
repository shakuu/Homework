using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Directions.Contracts;
using MatrixPath.Logic.Matrices.Contracts;
using MatrixPath.Logic.Values.Contracts;

namespace MatrixPath.Logic.Matrices
{
    public class BasicMatrix : IMatrix
    {
        private IList<IList<ICell>> theMatrix;
        private bool[][] visitedCellPositions;

        public BasicMatrix(int matrixSize, Func<int, int, int, ICell> createCell)
        {
            if (matrixSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Matrix size must be larger than 0");
            }

            if (createCell == null)
            {
                throw new ArgumentNullException("createCell");
            }

            this.theMatrix = this.CreateTheMatrix(matrixSize, createCell);
            this.visitedCellPositions = this.InitializeVisitedFlags(matrixSize);
        }

        public void Populate(IPosition startPosition, IDirectionSequence directionsInstructions, ICellValueSequence valueProvider)
        {
            var position = startPosition.Clone();
            var direction = directionsInstructions.GetNextDirection();
            var initialDirection = direction.Clone();

            var matrixSize = this.theMatrix.Count;
            var matrixIsFilled = false;
            do
            {
                var nextCellValue = valueProvider.GetNextCellValue();
                this.theMatrix[position.Row][position.Col].Value = nextCellValue;
                this.visitedCellPositions[position.Row][position.Col] = true;

                var nextPosition = position.Clone();
                nextPosition = nextPosition.MoveInDirection(direction);

                var nextPositionIsFree = this.CheckIfPositionIsValidToMove(nextPosition, matrixSize);
                if (!nextPositionIsFree)
                {
                    for (int directionChangeCount = 1; directionChangeCount <= directionsInstructions.DirectionSequenceLength; directionChangeCount++)
                    {
                        var nextDirection = directionsInstructions.GetNextDirection();
                        nextPosition = position.Clone();
                        nextPosition = nextPosition.MoveInDirection(nextDirection);

                        nextPositionIsFree = this.CheckIfPositionIsValidToMove(nextPosition, matrixSize);
                        if (nextPositionIsFree)
                        {
                            direction = nextDirection;
                            break;
                        }
                        else if (directionChangeCount == directionsInstructions.DirectionSequenceLength)
                        {
                            nextPosition = this.FindPositionToJumpTo(nextPosition, matrixSize);
                            if (nextPosition == null)
                            {
                                matrixIsFilled = true;
                                break;
                            }
                            else
                            {
                                direction = initialDirection.Clone();
                            }
                        }
                    }
                }

                position = nextPosition;
            }
            while (!matrixIsFilled);
        }

        public override string ToString()
        {
            var stringRepresentation = new StringBuilder();

            var matrixSize = this.theMatrix.Count;
            for (int row = 0; row < matrixSize; row++)
            {
                var currentRow = new StringBuilder();
                for (int col = 0; col < matrixSize; col++)
                {
                    currentRow.Append(this.theMatrix[row][col].Value + " ");
                }

                stringRepresentation.AppendLine(currentRow.ToString().Trim());
            }

            return stringRepresentation.ToString();
        }

        private IPosition FindPositionToJumpTo(IPosition position, int matrixSize)
        {
            IPosition newPosition = null;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (!this.visitedCellPositions[row][col])
                    {
                        newPosition = position.MoveTo(row, col);
                        return newPosition;
                    }
                }
            }

            return newPosition;
        }

        private bool CheckForAvailablePositionToJump()
        {
            var availablePosition = this.visitedCellPositions
                .Any(flagsArr => flagsArr.Any(flag => flag == false));

            return availablePosition;
        }

        private bool CheckIfPositionIsValidToMove(IPosition position, int matrixSize)
        {
            var isValid = true;

            var rowOutOfBounds = position.Row < 0 || matrixSize <= position.Row;
            var colOutOfBounds = position.Col < 0 || matrixSize <= position.Col;

            var isOutOfBounds = rowOutOfBounds || colOutOfBounds;
            if (isOutOfBounds)
            {
                isValid = false;
            }
            else
            {
                var cellIsVisited = this.visitedCellPositions[position.Row][position.Col];
                isValid = !cellIsVisited;
            }

            return isValid;
        }

        private IList<IList<ICell>> CreateTheMatrix(int size, Func<int, int, int, ICell> createCell)
        {
            var cellDefaultValue = 0;
            var theMatrix = new List<IList<ICell>>();
            for (int rowIndex = 0; rowIndex < size; rowIndex++)
            {
                var nextMatrixRow = new List<ICell>();
                for (int colIndex = 0; colIndex < size; colIndex++)
                {
                    var cellToAdd = createCell(rowIndex, colIndex, cellDefaultValue);
                    nextMatrixRow.Add(cellToAdd);
                }

                theMatrix.Add(nextMatrixRow);
            }

            return theMatrix;
        }

        private bool[][] InitializeVisitedFlags(int size)
        {
            var flags = new bool[size][];
            for (int row = 0; row < size; row++)
            {
                flags[row] = new bool[size];
            }

            return flags;
        }
    }
}
