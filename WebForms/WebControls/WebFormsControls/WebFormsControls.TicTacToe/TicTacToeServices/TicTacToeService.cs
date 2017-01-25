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
            var result = this.modelFactory.CreateTicTacToeViewModel();

            if (this.IsLoss(currentGameBoard))
            {
                result.Message = "lucky";
                result.GameBoard = currentGameBoard;

                return result;
            }

            if (this.IsFull(currentGameBoard))
            {
                result.Message = "Game Over!";
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

        private bool IsFull(IList<IList<string>> gameBoard)
        {
            var isFull = true;
            for (int row = 0; row < gameBoard.Count; row++)
            {
                for (int col = 0; col < gameBoard[row].Count; col++)
                {
                    if (gameBoard[row][col] != "X" && gameBoard[row][col] != "O")
                    {
                        isFull = false;
                        break;
                    }
                }

                if (!isFull)
                {
                    break;
                }
            }

            return isFull;
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
            var rowCount = 0;
            var columnCount = 0;
            for (int col = 0; col < 3; col++)
            {
                rowCount = 0;
                columnCount = 0;
                for (int row = 0; row < 3; row++)
                {
                    if (isMatchingTokenPredicate(gameBoard[row][col]))
                    {
                        columnCount++;
                    }

                    if (isMatchingTokenPredicate(gameBoard[col][row]))
                    {
                        rowCount++;
                    }
                }

                if (columnCount == 3 || rowCount == 3)
                {
                    break;
                }
            }

            return columnCount == 3 || rowCount == 3;
        }

        private bool IsDiagonal(IList<IList<string>> gameBoard, Func<string, bool> isMatchingTokenPredicate)
        {
            var diagonalLeftCount = 0;
            var diagonalRightCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (isMatchingTokenPredicate(gameBoard[i][i]))
                {
                    diagonalRightCount++;
                }

                if (isMatchingTokenPredicate(gameBoard[2 - i][i]))
                {
                    diagonalLeftCount++;
                }
            }

            var isDiagonalRight = diagonalRightCount == 3;
            var isDiagonalLeft = diagonalLeftCount == 3;

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
