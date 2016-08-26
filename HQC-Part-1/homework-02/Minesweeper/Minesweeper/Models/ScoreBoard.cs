using System;
using System.Collections.Generic;
using System.Reflection;

using Minesweeper.Contracts;

namespace Minesweeper.Models
{
    /// <summary>
    /// Stores scores associated with names.
    /// </summary>
    public class ScoreBoard : IScoreBoard
    {
        private ConstructorInfo constructorToUse;

        private ICollection<IScoreCard> scores;

        /// <summary>
        /// Create a new ScoreBoard.
        /// </summary>
        /// <param name="typeOfScoreCardToUse"> Type of IScoreCard to use. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public ScoreBoard(Type typeOfScoreCardToUse)
        {
            if (typeOfScoreCardToUse == null)
            {
                throw new ArgumentNullException("typeOfScoreCardToUse");
            }

            var getIScoreCardInterface = typeOfScoreCardToUse.GetInterface("IScoreCard");
            if (getIScoreCardInterface == null)
            {
                throw new ArgumentException("Incorrect type.");
            }

            var getConstructor = this.GetConstructorToUse(typeOfScoreCardToUse);
            if (getConstructor == null)
            {
                throw new ArgumentException("Constructor not found.");
            }

            this.constructorToUse = getConstructor;
            this.scores = new HashSet<IScoreCard>();
        }

        /// <summary>
        /// Add a new element to the IScoreBoard.
        /// </summary>
        /// <param name="name"> Name to associate the score with. </param>
        /// <param name="score"> Number of points. </param>
        public void AddScoreCard(string name, int score)
        {
            var newScoreCard = (IScoreCard)this.constructorToUse.Invoke(new object[] { name, score });
            this.scores.Add(newScoreCard);
        }

        /// <summary>
        /// Get the top number scores stored.
        /// </summary>
        /// <param name="number"> The number of scores to return. </param>
        /// <returns> IEnumerable containg the number of scores requested. </returns>
        public IEnumerable<IScoreCard> GetTopScores(int number)
        {
            throw new NotImplementedException();
        }

        private ConstructorInfo GetConstructorToUse(Type type)
        {
            var constructorToUse = type.GetConstructor(
                BindingFlags.Public | BindingFlags.Instance,
                null,
                new[] { typeof(string), typeof(int) },
                null);

            return constructorToUse;
        }
    }
}
