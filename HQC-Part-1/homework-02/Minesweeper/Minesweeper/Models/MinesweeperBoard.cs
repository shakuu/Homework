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
            this.CheckIfIntegerIsLargerThanZero(sizeRows);
            this.CheckIfIntegerIsLargerThanZero(sizeCols);
            this.CheckIfIntegerIsLargerThanZero(numberOfMines);

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
        public IEnumerable<IEnumerable<string>> GameBoardToDisplay
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
        public void SetContentAtCoordinates(int row, int column)
        {
            this.CheckIfIntegerIsLargerThanZero(row);
            this.CheckIfIntegerIsLargerThanZero(column);

            this.CheckIfCoordinateIsLargerThanBoardSize(row, this.NumberOfRows);
            this.CheckIfCoordinateIsLargerThanBoardSize(column, this.NumberOfColumns);

            var content = this.DetermineCellContentBasedOnSurroundingMines(row, column);
            this.visibleGrid[row][column] = content;
        }

        /// <summary>
        /// Generate a new grid with the specified size and number of mines.
        /// </summary>
        public void GenerateGameBoard()
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
                var row = mineModifier % this.NumberOfColumns;
                var column = mineModifier / this.NumberOfRows;

                // TODO: Double check original algorithm
                this.minesGrid[row - 1][column - 1] = MinesweeperBoard.MineCellSymbol;
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
                grid[row] = new List<string>();
                for (int col = 0; col < this.NumberOfColumns; col++)
                {
                    grid[row].Add(symbol);
                }
            }
        }

        private string DetermineCellContentBasedOnSurroundingMines(int row, int col)
        {
            throw new NotImplementedException();
        }
        
        private void CheckIfIntegerIsLargerThanZero(int value)
        {
            if (value <= 0)
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
