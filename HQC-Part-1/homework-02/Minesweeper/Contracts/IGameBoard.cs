using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    public interface IGameBoard
    {
        IEnumerable<IEnumerable<string>> GameBoard { get; }

        string GetContentAtCoordinates(int row, int col);

        void SetContentAtCoordinates(string content, int row, int col);

        void ResetGameBoard();
    }
}
