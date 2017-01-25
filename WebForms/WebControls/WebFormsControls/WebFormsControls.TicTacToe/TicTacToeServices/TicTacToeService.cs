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
            var result = this.modelFactory.GetTicTacToeViewModel();

            if (this.IsLoss(currentGameBoard))
            {
                result.Message = "lucky";
                result.GameBoard = currentGameBoard;

                return result;
            }

            var nextGameBoard = this.gameStrategy.GetNextMove(currentGameBoard);

            if (this.IsWin(nextGameBoard))
            {
                result.Message = "gg";
                result.GameBoard = nextGameBoard;

                return result;
            }

            result.Message = "Your turn";
            result.GameBoard = nextGameBoard;

            return result;
        }

        private bool IsLoss(IList<IList<string>> gameBoard)
        {
            if (this.IsDiagonal(gameBoard, this.IsPlayerTokenMatch))
            {
                return true;
            }

            if (this.IsRowOrColumn(gameBoard, this.IsPlayerTokenMatch))
            {
                return true;
            }

            return false;
        }

        private bool IsWin(IList<IList<string>> gameBoard)
        {
            if (this.IsDiagonal(gameBoard, this.IsBotTokenMatch))
            {
                return true;
            }

            if (this.IsRowOrColumn(gameBoard, this.IsBotTokenMatch))
            {
                return true;
            }

            return false;
        }

        private bool IsRowOrColumn(IList<IList<string>> gameBoard, Func<string, bool> isMatchingTokenPredicate)
        {
            var isRow = false;
            var isColumn = false;
            for (int col = 0; col < 3; col++)
            {
                isRow = false;
                isColumn = false;
                for (int row = 0; row < 3; row++)
                {
                    if (isMatchingTokenPredicate(gameBoard[row][col]))
                    {
                        isColumn = true;
                    }
                    else
                    {
                        isColumn = false;
                    }

                    if (isMatchingTokenPredicate(gameBoard[col][row]))
                    {
                        isRow = true;
                    }
                    else
                    {
                        isRow = false;
                    }
                }

                if (isColumn || isRow)
                {
                    break;
                }
            }

            return isColumn || isRow;
        }

        private bool IsDiagonal(IList<IList<string>> gameBoard, Func<string, bool> isMatchingTokenPredicate)
        {
            var isDiagonalRight = false;
            var isDiagonalLeft = false;
            for (int i = 0; i < 3; i++)
            {
                if (isMatchingTokenPredicate(gameBoard[i][i]))
                {
                    isDiagonalRight = true;
                }
                else
                {
                    isDiagonalRight = false;
                }

                if (isMatchingTokenPredicate(gameBoard[2 - i][i]))
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

        private bool IsBotTokenMatch(string value)
        {
            return value == "X";
        }

        private bool IsPlayerTokenMatch(string value)
        {
            return value == "O";
        }
    }
}
