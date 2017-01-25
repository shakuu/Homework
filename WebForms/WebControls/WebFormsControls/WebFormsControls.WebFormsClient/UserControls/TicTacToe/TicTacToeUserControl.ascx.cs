using System;

using WebFormsControls.TicTacToe;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsControls.WebFormsClient.UserControls.TicTacToe
{
    [PresenterBinding(typeof(ITicTacToePresenter))]
    public partial class TicTacToeUserControl : MvpUserControl<TicTacToeViewModel>, ITicTacToeView
    {
        public event EventHandler<TicTacToeEventArgs> PlayerTurn;
    }
}