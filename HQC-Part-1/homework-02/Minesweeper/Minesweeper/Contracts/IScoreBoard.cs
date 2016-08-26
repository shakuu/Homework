using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    /// <summary>
    /// Stores scores associated with names.
    /// </summary>
    public interface IScoreBoard
    {

        /// <summary>
        /// Add a new element to the IScoreBoard.
        /// </summary>
        /// <param name="name"> Name to associate the score with. </param>
        /// <param name="score"> Number of points. </param>
        void AddScoreCard(string name, int score);

        /// <summary>
        /// Get the top number scores stored.
        /// </summary>
        /// <param name="number"> The number of scores to return. </param>
        /// <returns> IEnumerable containg the number of scores requested. </returns>
        IList<IScoreCard> GetTopScores(int number);

    }
}
