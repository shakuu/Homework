using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebFormsControls.TicTacToe;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsControls.WebFormsClient.UserControls.TicTacToe
{
    [PresenterBinding(typeof(ITicTacToePresenter))]
    public partial class TicTacToeUserControl : MvpUserControl<TicTacToeViewModel>, ITicTacToeView
    {
        private const string SessionStateFieldName = "TicTacToe";

        public event EventHandler<TicTacToeEventArgs> PlayerTurn;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Model.GameBoard = this.RestoreGameBoardFromSession();
            this.Model.Message = "Welcome!";
        }

        protected void OnUserInput(object sender, EventArgs e)
        {
            var senderButton = sender as Button;
            if (sender == null)
            {
                return;
            }

            this.Model.GameBoard = this.RestoreGameBoardFromSession();

            var senderId = senderButton.ID;
            var userInputRow = senderId[1].ToString();
            var userInputCol = senderId[2].ToString();
            var userInputContent = senderButton.Text;

            var args = new TicTacToeEventArgs(userInputRow, userInputCol, userInputContent, this.Model.GameBoard);
            this.PlayerTurn(this, args);

            Session[TicTacToeUserControl.SessionStateFieldName] = this.Model.GameBoard;
        }

        private IList<IList<string>> RestoreGameBoardFromSession()
        {
            var gameBoardFromSession = Session[TicTacToeUserControl.SessionStateFieldName];
            if (gameBoardFromSession != null)
            {
                return (IList<IList<string>>)gameBoardFromSession;
            }
            else
            {
                return this.Model.GameBoard;
            }
        }
    }
}