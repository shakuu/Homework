using System.Collections.Generic;

namespace Dealership.Data.Contracts
{
    public interface ICommentable
    {
        IList<IComment> Comments { get; }
    }
}
