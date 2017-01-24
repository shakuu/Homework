using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToePresenter : Presenter<ITicTacToeView>
    {
        private readonly ITicTacToeView view;

        public TicTacToePresenter(ITicTacToeView view)
            : base(view)
        {
            this.view = view;
            this.view.PlayerTurn += this.OnPlayerTurn;
        }

        private void OnPlayerTurn(object sender, TicTacToeEventArgs args)
        {

        }
    }
}
