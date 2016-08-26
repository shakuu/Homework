using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    /// <summary>
    /// Prived methods for displaying the game to the user.
    /// </summary>
    public interface IUserInterface
    {

        /// <summary>
        /// Returns the User Nickname.
        /// </summary>
        /// <returns> Return a string containing the user name. </returns>
        string GetUserNickname();

        /// <summary>
        /// Read input from the user and return it as string.
        /// </summary>
        /// <returns> Return a string with a user command. </returns>
        string ReadUserInput();

        /// <summary>
        /// Display the IGameBoard for the user.
        /// </summary>
        /// <param name="gameBoard"> IGameBoard object to display. </param>
        void DisplayGameBoard(IGameBoard gameBoard);

        /// <summary>
        /// Display High Score List to the user.
        /// </summary>
        /// <param name="scoreList"> List of IScoreCard objects to display. </param>
        void DisplayHighScore(IEnumerable<IScoreCard> scoreList);

        /// <summary>
        /// Display a message to the user.
        /// </summary>
        /// <param name="message"> Message to display. </param>
        void DisplayMessage(string message);
    }
}
