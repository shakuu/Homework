using System;
using System.Collections.Generic;

using WebFormsControls.TicTacToe.TicTacToeServices.Contracts;

namespace WebFormsControls.TicTacToe.TicTacToeServices.Strategies
{
    public class SimpletonTicTacToeStrategy : ITicTacToeStrategy
    {
        private static Random Random = new Random();

        public IList<IList<string>> GetNextMove(IList<IList<string>> currentGameBoard)
        {
            while (true)
            {
                var row = SimpletonTicTacToeStrategy.Random.Next(0, 4);
                var col = SimpletonTicTacToeStrategy.Random.Next(0, 4);

                if (currentGameBoard[row][col] != "O")
                {
                    currentGameBoard[row][col] = "X";
                    break;
                }
            }

            return currentGameBoard;
        }
    }
}
