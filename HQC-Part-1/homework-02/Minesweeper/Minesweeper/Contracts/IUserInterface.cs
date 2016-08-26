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
        /// <returns></returns>
        string ReadUserNickname();

        /// <summary>
        /// Read input from the user and return it as string.
        /// </summary>
        /// <returns></returns>
        string ReadUserInput();

        /// <summary>
        /// Display the IGameBoard for the user.
        /// </summary>
        /// <param name="gameBoard"></param>
        void DisplayGameBoard(IGameBoard gameBoard);

        /// <summary>
        /// Display High Score List to the user.
        /// </summary>
        /// <param name="scoreList"></param>
        void DisplayHighScore(IEnumerable<IScoreCard> scoreList);

        /// <summary>
        /// Display a message to the user.
        /// </summary>
        /// <param name="message"> Message to display. </param>
        void DisplayMessage(string message);
    }
}
