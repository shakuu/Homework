using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormsControls.TicTacToe.Factories
{
    public interface ITicTacToeViewModelFactory
    {
        TicTacToeViewModel CreateTicTacToeViewModel();
    }
}
