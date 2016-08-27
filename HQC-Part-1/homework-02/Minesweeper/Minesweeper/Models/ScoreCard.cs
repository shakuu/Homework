using System;

using Minesweeper.Contracts;

namespace Minesweeper.Models
{
    /// <summary>
    /// Creates a ScoreCard containing the Name of the player and the points score achieved.
    /// </summary>
    public class ScoreCard : IScoreCard
    {
        private string name;
        private int score;

        /// <summary>
        /// Create a new ScoreCard instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public ScoreCard(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        /// <summary>
        /// Player name associated with this score.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Throws when value is null or empty. </exception>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ScoreCard.Name");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Score represented by points.
        /// </summary>
        /// <exception cref="ArgumentException"> Throws when score is a negative number. </exception>
        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ScoreCard.Score");
                }

                this.score = value;
            }
        }
    }
}
