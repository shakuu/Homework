using WebFormsControls.TicTacToe.TicTacToeServices.Contracts;

using WebFormsMvp;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToePresenter : Presenter<ITicTacToeView>, ITicTacToePresenter
    {
        private readonly ITicTacToeView view;
        private readonly ITicTacToeService gameService;

        public TicTacToePresenter(ITicTacToeView view, ITicTacToeService gameService)
            : base(view)
        {
            this.view = view;
            this.view.PlayerTurn += this.OnPlayerTurn;

            this.gameService = gameService;
        }

        private void OnPlayerTurn(object sender, TicTacToeEventArgs args)
        {
            var currentGameBoard = args.CurrentGameBoard;

            var nextState = this.gameService.EvaluateGameBoard(currentGameBoard);

            this.view.Model = nextState;
        }
    }
}
 