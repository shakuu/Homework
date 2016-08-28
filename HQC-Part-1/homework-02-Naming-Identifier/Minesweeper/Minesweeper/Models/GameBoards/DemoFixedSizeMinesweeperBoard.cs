namespace Minesweeper.Models.GameBoards
{
    /// <summary>
    /// Inherits MinesweeperBoard with constant constructor parameters for Demo purposes.
    /// </summary>
    /// <seealso cref="Minesweeper.Models.MinesweeperBoard"/>
    public class DemoFixedSizeMinesweeperBoard : MinesweeperBoard
    {
        private const int FixedNumberOfRows = 5;
        private const int FixedNumberOfColumns = 10;
        private const int FixedNumberOfMines = 15;

        /// <summary>
        /// Create a Demo MinesweeperBoard with a fixed size and number of mines.
        /// </summary>
        /// <seealso cref="Minesweeper.Models.MinesweeperBoard"/>
        public DemoFixedSizeMinesweeperBoard()
            : base(
                  DemoFixedSizeMinesweeperBoard.FixedNumberOfRows,
                  DemoFixedSizeMinesweeperBoard.FixedNumberOfColumns,
                  DemoFixedSizeMinesweeperBoard.FixedNumberOfMines)
        {
        }
    }
}
