using System;

using Minesweeper.Contracts;

namespace Minesweeper.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var game = CreateGame();
            while(game.IsRunning)
            {
                game.ExecuteNextGameCycle();
            }
        }

        private static IGameEngine CreateGame()
        {
            throw new NotImplementedException();
        }
    }
}
