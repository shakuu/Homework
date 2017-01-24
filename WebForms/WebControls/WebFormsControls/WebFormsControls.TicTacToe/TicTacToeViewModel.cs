using System.Collections.Generic;

namespace WebFormsControls.TicTacToe
{
    public class TicTacToeViewModel
    {
        public TicTacToeViewModel()
        {
            this.PlayingField = new List<string>[3];
            for (int row = 0; row < this.PlayingField.Count; row++)
            {
                this.PlayingField[row] = new string[3];
            }
        }

        public IList<IList<string>> PlayingField { get; set; }
    }
}
