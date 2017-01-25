using System;

using WebFormsControls.TicTacToe.TicTacToeServices.Contracts;

using WebFormsMvp;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToePresenter : Presenter<ITicTacToeView>, ITicTacToePresenter
    {
        private const string GameBoardEmptyCell = "-";
        private const string GameBoardPlayerMarker = "O";

        private readonly ITicTacToeView view;
        private readonly ITicTacToeService gameService;

        public TicTacToePresenter(ITicTacToeView view, ITicTacToeService gameService)
            : base(view)
        {
            this.view = view;
            this.view.PlayerTurn += this.OnPlayerTurn;
            this.view.NewGame += this.OnNewGame;

            this.gameService = gameService;
        }

        private void OnNewGame(object sender, EventArgs args)
        {
            var newModelState = this.gameService.ResetGame();
            this.view.Model = newModelState;
        }

        private void OnPlayerTurn(object sender, TicTacToeEventArgs args)
        {
            var currentGameBoard = args.CurrentGameBoard;
            var playerInputRow = int.Parse(args.PlayerTurnRow);
            var playerInputCol = int.Parse(args.PlayerTurnCol);
            var playerInputContent = args.PlayerInputContent;

            if (playerInputContent == TicTacToePresenter.GameBoardEmptyCell)
            {
                currentGameBoard[playerInputRow][playerInputCol] = TicTacToePresenter.GameBoardPlayerMarker;
            }
            else
            {
                return;
            }

            var nextModelState = this.gameService.EvaluateGameBoard(currentGameBoard);

            this.view.Model = nextModelState;
        }
    }
}
