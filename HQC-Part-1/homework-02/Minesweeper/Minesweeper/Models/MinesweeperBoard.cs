using System;
using System.Collections.Generic;

using Minesweeper.Contracts;

namespace Minesweeper.Models
{
    /// <summary>
    /// IGameBoard implementation for Minesweeper.
    /// </summary>
    public class MinesweeperBoard : IGameBoard
    {
        private const string MineCellSymbol = "*";
        private const string EmptyCellSymbol = "-";
        private const string UncheckedCellSymbol = "?";

        private int rows;
        private int cols;
        private int numberOfMines;

        private IList<IList<string>> visibleGrid;
        private IList<IList<string>> minesGrid;

        /// <summary>
        /// Creates a new instance with the sepcified parameters.
        /// </summary>
        /// <param name="sizeRows"> Specifies the number of rows in the grid. </param>
        /// <param name="sizeCols"> Specifies the number of columns in the grid. </param>
        /// <param name="numberOfMines"> Specifies the number of mines in the grid. </param>
        /// <exception cref="ArgumentOutOfRangeException"> Throws when any of the parameters are less than or equal to 0. </exception>
        public MinesweeperBoard(int sizeRows, int sizeCols, int numberOfMines)
        {
            this.CheckIfIntegerIsLessThanZero(sizeRows);
            this.CheckIfIntegerIsLessThanZero(sizeCols);
            this.CheckIfIntegerIsLessThanZero(numberOfMines);

            this.rows = sizeRows;
            this.cols = sizeCols;
            this.numberOfMines = numberOfMines;
        }

        /// <summary>
        /// Size of the IGameBoard in rows.
        /// </summary>
        public int NumberOfRows
        {
            get
            {
                return this.rows;
            }
        }

        /// <summary>
        /// Size of the IGameBoard in columns.
        /// </summary>
        public int NumberOfColumns
        {
            get
            {
                return this.cols;
            }
        }

        /// <summary>
        /// Provides the IGameBoard to display.
        /// </summary>
        public IList<IList<string>> GameBoardToDisplay
        {
            get
            {
                var copyOfVisibleGrid = new List<IList<string>>(this.visibleGrid);
                return copyOfVisibleGrid;
            }
        }

        /// <summary>
        /// Return whether the specified position is empty or not.
        /// </summary>
        /// <param name="row"> Row coordinate. </param>
        /// <param name="col"> Column coordinate. </param>
        /// <returns> Return True if the specified coordinate is empty. </returns>
        public bool IsCellAtCoordinatesEmpty(int row, int col)
        {
            var isCellEmpty = true;
            if (this.minesGrid[row][col] == MinesweeperBoard.MineCellSymbol)
            {
                isCellEmpty = false;
            }

            return isCellEmpty;
        }

        /// <summary>
        /// Sets the content of the cell at the specified position on the visible grid to the specified symbol.
        /// </summary>
        /// <param name="row"> Row coordinate. </param>
        /// <param name="column"> Column coordinate. </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void UpdateCellContentAtCoordinates(int row, int column)
        {
            this.CheckIfIntegerIsLessThanZero(row);
            this.CheckIfIntegerIsLessThanZero(column);

            this.CheckIfCoordinateIsLargerThanBoardSize(row, this.NumberOfRows);
            this.CheckIfCoordinateIsLargerThanBoardSize(column, this.NumberOfColumns);

            var cellContent = string.Empty;

            var isMinsAtPosition = this.minesGrid[row][column] == MinesweeperBoard.MineCellSymbol;
            if (isMinsAtPosition)
            {
                cellContent = MinesweeperBoard.MineCellSymbol;
            }
            else
            {
                cellContent = this.DetermineCellContentBasedOnSurroundingMines(row, column);
            }

            this.visibleGrid[row][column] = cellContent;
        }

        /// <summary>
        /// Generate a new grid with the specified size and number of mines.
        /// </summary>
        public void GenerateNewGameBoard()
        {
            this.GenerateVisibleGrid();
            this.GenereateMinesGrid();
        }

        private void GenerateVisibleGrid()
        {
            this.visibleGrid = new List<IList<string>>();
            this.SetAllCellsInAGridToSymbol(this.visibleGrid, MinesweeperBoard.UncheckedCellSymbol);
        }

        private void GenereateMinesGrid()
        {
            this.minesGrid = new List<IList<string>>();
            this.SetAllCellsInAGridToSymbol(this.minesGrid, MinesweeperBoard.EmptyCellSymbol);

            var minesPositionsModifiers
                = this.RandomizeMinesPositions(this.numberOfMines, this.NumberOfRows, this.NumberOfColumns);

            foreach (var mineModifier in minesPositionsModifiers)
            {
                var row = mineModifier % this.NumberOfRows;
                var column = mineModifier / this.NumberOfRows;

                column = column == 0 ? column + 1 : column;
                this.minesGrid[row][column - 1] = MinesweeperBoard.MineCellSymbol;
            }
        }

        private IEnumerable<int> RandomizeMinesPositions(int numberOfMines, int rowsSize, int columnsSize)
        {
            var minesPositionsModifiers = new HashSet<int>();

            var randomNumberGenerator = new Random();
            var maximumRandomNumber = rowsSize * columnsSize;
            while (minesPositionsModifiers.Count < numberOfMines)
            {
                var nextRandomNumber = randomNumberGenerator.Next(0, maximumRandomNumber);
                minesPositionsModifiers.Add(nextRandomNumber);
            }

            return minesPositionsModifiers;
        }

        private void SetAllCellsInAGridToSymbol(IList<IList<string>> grid, string symbol)
        {
            for (int row = 0; row < this.NumberOfRows; row++)
            {
                grid.Add(new List<string>());
                for (int col = 0; col < this.NumberOfColumns; col++)
                {
                    grid[row].Add(symbol);
                }
            }
        }

        private string DetermineCellContentBasedOnSurroundingMines(int rowCoordinate, int colCoordinate)
        {
            var startRow = Math.Max(rowCoordinate - 1, 0);
            var endRow = Math.Min(rowCoordinate + 1, this.NumberOfRows - 1);

            var startCol = Math.Max(colCoordinate - 1, 0);
            var endCol = Math.Min(colCoordinate + 1, this.NumberOfColumns - 1);

            var surroundingMinesCount = 0;
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (this.minesGrid[row][col] == MinesweeperBoard.MineCellSymbol)
                    {
                        surroundingMinesCount++;
                    }
                }
            }

            return surroundingMinesCount.ToString();
        }
        
        private void CheckIfIntegerIsLessThanZero(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("MinesweeperBoard constructor.");
            }
        }

        private void CheckIfCoordinateIsLargerThanBoardSize(int value, int boardSize)
        {
            if (boardSize < value)
            {
                throw new ArgumentOutOfRangeException("Coordinate outside GameBoard dimensions.");
            }
        }
    }
}
