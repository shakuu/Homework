namespace Minesweeper.Contracts
{
    /// <summary>
    /// Creates a ScoreCard containing the Name of the player and the points score achieved.
    /// </summary>
    public interface IScoreCard
    {
        /// <summary>
        /// Player name associated with this score.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Score represented by points.
        /// </summary>
        int Score { get; }
    }
}
