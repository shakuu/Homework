using _02_Kitty.Engine.Contracts;

namespace _02_Kitty.Results.Contracts
{
    public interface IResultTracker
    {
        bool EvaluateCell(IPathCell pathCell);

        string CreateReport();
    }
}
