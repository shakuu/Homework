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

        }

        /// <summary>
        /// Display the IGameBoard for the user.
        /// </summary>
        /// <param name="gameBoard"> IGameBoard object to display. </param>
        public void DisplayGameBoard(IGameBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Display High Score List to the user.
        /// </summary>
        /// <param name="scoreList"> List of IScoreCard objects to display. </param>
        public void DisplayHighScore(IEnumerable<IScoreCard> scoreList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Display a message to the user.
        /// </summary>
        /// <param name="message"> Message to display. </param>
        public void DisplayMessage(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the User Nickname.
        /// </summary>
        /// <returns> Return a string containing the user name. </returns>
        public string GetUserNickname()
        {
            throw new NotImplementedException();
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
