using System.Collections.Generic;

namespace WebFormsControls.TicTacToe.TicTacToeServices.Contracts
{
    public interface ITicTacToeService
    {
        IList<IList<string>> EvaluateGameBoard(IList<IList<string>> currentGameBoard);
    }
}
