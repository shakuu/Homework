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
        private const string SessionStateGameOverName = "GameOver";

        public event EventHandler<TicTacToeEventArgs> PlayerTurn;
        public event EventHandler NewGame;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Model.GameBoard = this.RestoreGameBoardFromSession();
            this.Model.IsGameOver = this.RestoreIsGameOverFromSession();
            if (this.Model.IsGameOver)
            {
                this.Model.Message = "Game Over!";
            }
            else
            {
                this.Model.Message = "Welcome!";
            }
        }

        protected void OnUserInput(object sender, EventArgs e)
        {
            if (this.Model.IsGameOver)
            {
                return;
            }

            var senderButton = sender as Button;
            if (sender == null)
            {
                return;
            }

            var senderId = senderButton.ID;
            var userInputRow = senderId[1].ToString();
            var userInputCol = senderId[2].ToString();
            var userInputContent = senderButton.Text;

            var args = new TicTacToeEventArgs(userInputRow, userInputCol, userInputContent, this.Model.GameBoard);
            this.PlayerTurn(this, args);

            this.SaveGameStateToSession(this.Model.GameBoard, this.Model.IsGameOver);
        }

        protected void OnNewGame(object sender, EventArgs e)
        {
            this.NewGame(this, null);

            this.SaveGameStateToSession(this.Model.GameBoard, this.Model.IsGameOver);
        }

        private void SaveGameStateToSession(IList<IList<string>> gameBoard, bool isGameOver)
        {

            Session[TicTacToeUserControl.SessionStateFieldName] = gameBoard;
            Session[TicTacToeUserControl.SessionStateGameOverName] = isGameOver;
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

        private bool RestoreIsGameOverFromSession()
        {
            var sessionValue = Session[TicTacToeUserControl.SessionStateGameOverName];
            if (sessionValue == null)
            {
                return false;
            }
            else
            {
                return (bool)sessionValue;
            }
        }
    }
}