using System;

using Minesweeper.Contracts;
using Minesweeper.Engine;
using Minesweeper.Models;
using Minesweeper.UI;

namespace Minesweeper.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var successfulTurnsToWin = 35;
            var numberOfGameBoardRows = 5;
            var numberOfGameBoardColumns = 10;
            var numberOfGameBoardMines = 15;

            var game = CreateGame(
                successfulTurnsToWin,
                numberOfGameBoardRows,
                numberOfGameBoardColumns,
                numberOfGameBoardMines);

            game.StartNewGame();
            while (game.IsRunning)
            {
                game.ExecuteNextGameCycle();
            }

            Console.Read();
        }

        private static IGameEngine CreateGame(
            int successfulTurnsToWin,
            int numberOfRows,
            int numberOfColumns,
            int numberOfMines)
        {
            var scoreBoard = new ScoreBoard(typeof(ScoreCard));
            var userInterFace = new ConsoleUserInterface(numberOfRows, numberOfColumns);
            var gameBoard = new MinesweeperBoard(numberOfRows, numberOfColumns, numberOfMines);
            var minesweeper = new MinesweeperEngine(successfulTurnsToWin, gameBoard, scoreBoard, userInterFace);

            return minesweeper;
        }
    }
}
