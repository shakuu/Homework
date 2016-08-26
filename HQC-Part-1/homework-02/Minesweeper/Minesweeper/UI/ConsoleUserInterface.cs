using System;
using System.Collections.Generic;

using Minesweeper.Contracts;

namespace Minesweeper.UI
{
    /// <summary>
    /// Implements IUserInterface using System.Console
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        private int gameBoardRows;
        private int gameBoardColumns;

        /// <summary>
        /// Creates a new ConsoleUserInterface.
        /// </summary>
        /// <param name="gameBoardRows"></param>
        /// <param name="gameBoardColumns"></param>
        public ConsoleUserInterface(int gameBoardRows, int gameBoardColumns)
        {
            this.gameBoardRows = gameBoardRows;
            this.gameBoardColumns = gameBoardColumns;
        }

        /// <summary>
        /// Display the IGameBoard for the user.
        /// </summary>
        /// <param name="gameBoard"> IGameBoard object to display. </param>
        public void DisplayGameBoard(IGameBoard gameBoard)
        {
            var gameBoardToDisplay = gameBoard.GameBoardToDisplay;
            var numberOfRows = gameBoardToDisplay.Count;
            var numberOfColumns = gameBoardToDisplay[0].Count;

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < numberOfRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Console.Write(string.Format("{0} ", gameBoardToDisplay[i][j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        /// <summary>
        /// Display High Score List to the user.
        /// </summary>
        /// <param name="scoreList"> List of IScoreCard objects to display. </param>
        public void DisplayHighScore(IList<IScoreCard> scoreList)
        {
            Console.WriteLine("Top Scores List: ");
            if (scoreList.Count > 0)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells.",
                        i + 1, scoreList[i].Name, scoreList[i].Score);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }

        /// <summary>
        /// Display a message to the user.
        /// </summary>
        /// <param name="message"> Message to display. </param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Returns the User Nickname.
        /// </summary>
        /// <returns> Return a string containing the user name. </returns>
        public string GetUserNickname()
        {
            Console.WriteLine();
            Console.WriteLine("Enter your name!");
            var userNickname = Console.ReadLine().Trim();

            return userNickname;
        }

        /// <summary>
        /// Read input from the user and return it as string.
        /// </summary>
        /// <returns> Return a string with a user command. </returns>
        public string ReadUserInput()
        {
            var userInput = Console.ReadLine().Trim();
            return userInput;
        }
    }
}
