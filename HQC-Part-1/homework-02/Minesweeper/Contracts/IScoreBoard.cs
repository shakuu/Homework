using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    public interface IScoreBoard
    {
        void AddScoreCard(IScoreCard scoreCard);

        IEnumerable<IScoreCard> GetTopScores(int number);

    }
}
