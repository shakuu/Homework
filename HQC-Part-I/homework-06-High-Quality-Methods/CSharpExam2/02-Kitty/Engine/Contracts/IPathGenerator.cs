using System.Collections.Generic;

namespace _02_Kitty.Engine.Contracts
{
    public interface IPathGenerator
    {
        IList<IPathCell> CreatePath(string path);
    }
}
