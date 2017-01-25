using System;

using WebFormsMvp;

namespace WebFormsControls.TicTacToe
{
    public interface ITicTacToeView : IView<TicTacToeViewModel>
    {
        event EventHandler<TicTacToeEventArgs> PlayerTurn;

        event EventHandler NewGame;
    }
}
