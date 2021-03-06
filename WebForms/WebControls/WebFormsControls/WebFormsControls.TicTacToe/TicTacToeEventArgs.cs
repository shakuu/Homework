﻿using System;
using System.Collections.Generic;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToeEventArgs : EventArgs
    {
        public TicTacToeEventArgs(string row, string col, string content, IList<IList<string>> currentGameBoard)
        {
            this.PlayerTurnRow = row;
            this.PlayerTurnCol = col;
            this.PlayerInputContent = content;
            this.CurrentGameBoard = currentGameBoard;
        }

        public string PlayerTurnRow { get; set; }

        public string PlayerTurnCol { get; set; }

        public string PlayerInputContent { get; set; }

        public IList<IList<string>> CurrentGameBoard { get; set; }
    }
}
