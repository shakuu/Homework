using System.Collections.Generic;

namespace WebFormsControls.TicTacToe.TicTacToeServices.Contracts
{
    public interface ITicTacToeService
    {
        TicTacToeViewModel EvaluateGameBoard(IList<IList<string>> currentGameBoard);
    }
}
