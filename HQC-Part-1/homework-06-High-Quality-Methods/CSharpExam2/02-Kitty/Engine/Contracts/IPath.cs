using _02_Kitty.Results.Contracts;

namespace _02_Kitty.Engine.Contracts
{
    public interface IPath
    {
        IResult EvaluteSequenceOfJumps(string sequence, IResult resultTracker);
    }
}
