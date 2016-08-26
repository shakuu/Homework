using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    public interface IGameBoard
    {
        IEnumerable<IEnumerable<string>> GameBoard { get; }

        bool CheckIfCoordinatesAreEmpty(int row, int col);
    }
}
