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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Model.Message = "Welcome!";
        }

        protected void OnUserInput(object sender, EventArgs e)
        {

        }
    }
}