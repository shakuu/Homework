using System;
using System.Collections.Generic;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToeEventArgs : EventArgs
    {
        public string PlayerTurnRow { get; set; }

        public string PlayerTurnCol { get; set; }

        public IList<IList<string>> CurrentGameBoard { get; set; }
    }
}
