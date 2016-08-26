using System;
using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    /// <summary>
    /// Describes a 2D game grid. Exposes its dimensions and relevat methods to game logic. 
    /// </summary>
    public interface IGameBoard
    {
        /// <summary>
        /// Size of the IGameBoard in rows.
        /// </summary>
        int NumberOfRows { get; }

        /// <summary>
        /// Size of the IGameBoard in columns.
        /// </summary>
        int NumberOfColumns { get; }

        /// <summary>
        /// Provides the IGameBoard to display.
        /// </summary>
        IList<IList<string>> GameBoardToDisplay { get; }

        /// <summary>
        /// Return whether the specified position is empty or not.
        /// </summary>
        /// <param name="row"> Row coordinate. </param>
        /// <param name="col"> Column coordinate. </param>
        /// <returns> Return True if the specified coordinate is empty. </returns>
        bool IsCellAtCoordinatesEmpty(int row, int col);

        /// <summary>
        /// Sets the content of the cell at the specified position on the visible grid to the specified symbol.
        /// </summary>
        /// <param name="row"> Row coordinate. </param>
        /// <param name="col"> Column coordinate. </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void SetContentAtCoordinates(int row, int col);

        /// <summary>
        /// Generate a new grid with the specified size and number of mines.
        /// </summary>
        void GenerateGameBoard();
    }
}
