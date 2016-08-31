using System.Collections.Generic;

namespace _02_Kitty.Engine.Contracts
{
    public interface ISequenceGenerator
    {
        IEnumerable<int> GenerateSequenceOfPostions(string sequence, int pathSize);
    }
}
