using System.Collections.Generic;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToeViewModel
    {
        public TicTacToeViewModel()
        {
            this.GameBoard = new IList<string>[3];
            for (int row = 0; row < this.GameBoard.Count; row++)
            {
                this.GameBoard[row] = new string[3];
                for (int col = 0; col < this.GameBoard[row].Count; col++)
                {
                    this.GameBoard[row][col] = "-";
                }
            }
        }

        public IList<IList<string>> GameBoard { get; set; }

        public string Message { get; set; }
    }
}
