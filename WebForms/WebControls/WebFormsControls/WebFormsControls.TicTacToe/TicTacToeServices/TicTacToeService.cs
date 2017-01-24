using System;
using System.Collections.Generic;
using WebFormsControls.TicTacToe.Factories;
using WebFormsControls.TicTacToe.TicTacToeServices.Contracts;

namespace WebFormsControls.TicTacToe.TicTacToeServices
{
    public class TicTacToeService : ITicTacToeService
    {
        private readonly ITicTacToeStrategy gameStrategy;
        private readonly ITicTacToeViewModelFactory modelFactory;

        public TicTacToeService(ITicTacToeStrategy gameStrategy, ITicTacToeViewModelFactory modelFactory)
        {
            this.gameStrategy = gameStrategy;
            this.modelFactory = modelFactory;
        }

        public TicTacToeViewModel EvaluateGameBoard(IList<IList<string>> currentGameBoard)
        {
            var nextGameBoard = this.gameStrategy.GetNextMove(currentGameBoard);
            return null;
        }

        private string GetMessage(IList<IList<string>> gameBoard)
        {
            var isWin = this.IsWin(gameBoard);
            if (isWin)
            {
                return "gg";
            }
            else
            {
                return "Your turn";
            }
        }

        private bool IsLoss(IList<IList<string>> gameBoard)
        {
            return false;
        }

        private bool IsWin(IList<IList<string>> gameBoard)
        {
            if (this.IsDiagonal(gameBoard))
            {
                return true;
            }

            if (this.IsColumn(gameBoard))
            {
                return true;
            }

            if (this.IsRow(gameBoard))
            {
                return true;
            }

            return false;
        }

        private bool IsRow(IList<IList<string>> gameBoard)
        {
            bool isColumn = false;
            for (int row = 0; row < 3; row++)
            {
                isColumn = false;
                for (int col = 0; col < 3; col++)
                {
                    if (this.IsMatch(gameBoard[row][col]))
                    {
                        isColumn = true;
                    }
                    else
                    {
                        isColumn = false;
                        break;
                    }
                }

                if (isColumn)
                {
                    break;
                }
            }

            return isColumn;
        }

        private bool IsColumn(IList<IList<string>> gameBoard)
        {
            bool isColumn = false;
            for (int col = 0; col < 3; col++)
            {
                isColumn = false;
                for (int row = 0; row < 3; row++)
                {
                    if (this.IsMatch(gameBoard[row][col]))
                    {
                        isColumn = true;
                    }
                    else
                    {
                        isColumn = false;
                        break;
                    }
                }

                if (isColumn)
                {
                    break;
                }
            }

            return isColumn;
        }

        private bool IsDiagonal(IList<IList<string>> gameBoard)
        {
            var isDiagonalRight = false;
            var isDiagonalLeft = false;
            for (int i = 0; i < 3; i++)
            {
                if (this.IsMatch(gameBoard[i][i]))
                {
                    isDiagonalRight = true;
                }
                else
                {
                    isDiagonalRight = false;
                }

                if (this.IsMatch(gameBoard[2 - i][i]))
                {
                    isDiagonalLeft = true;
                }
                else
                {
                    isDiagonalLeft = false;
                }
            }

            return isDiagonalRight || isDiagonalLeft;
        }

        private bool IsMatch(string value)
        {
            return value == "X";
        }
    }
}
