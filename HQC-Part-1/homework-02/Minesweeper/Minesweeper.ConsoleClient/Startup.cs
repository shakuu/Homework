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
            var game = CreateGame();

            game.StartNewGame();
            while(game.IsRunning)
            {
                game.ExecuteNextGameCycle();
            }

            Console.Read();
        }

        private static IGameEngine CreateGame()
        {
            var userInterFace = new ConsoleUserInterface(5, 10);
            var scoreBoard = new ScoreBoard(typeof(ScoreCard));
            var gameBoard = new MinesweeperBoard(5, 10, 15);
            var minesweeper = new MinesweeperEngine(35, gameBoard, scoreBoard, userInterFace);


            return minesweeper;
        }
    }
}
