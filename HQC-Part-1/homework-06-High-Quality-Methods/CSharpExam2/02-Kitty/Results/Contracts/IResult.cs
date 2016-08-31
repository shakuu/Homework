using _02_Kitty.Engine.Contracts;
using _02_Kitty.Utils.Contracts;

namespace _02_Kitty.Results.Contracts
{
    public interface IResult
    {
        string WriteResult(IWriter writer);

        bool EvaluateCell(IPathCell pathCell);
    }
}
