using System.Collections.Generic;

namespace WebFormsControls.TicTacToe.TicTacToeServices.Contracts
{
    public interface ITicTacToeStrategy
    {
        IList<IList<string>> GetNextMove(IList<IList<string>> currentGameBoard);
    }
}
