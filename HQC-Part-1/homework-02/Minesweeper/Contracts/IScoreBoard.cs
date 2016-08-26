using System.Collections.Generic;

namespace Minesweeper.Contracts
{
    public interface IScoreBoard
    {
        void AddScoreCard(string name, int score);

        IEnumerable<IScoreCard> GetTopScores(int number);

    }
}
