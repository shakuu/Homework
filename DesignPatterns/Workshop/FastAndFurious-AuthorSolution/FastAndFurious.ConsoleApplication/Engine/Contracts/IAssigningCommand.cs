using System.Collections.Generic;

namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IAssigningCommand : ICommand
    {
        int GetObjectToAssignId(IList<string> commandParameters);

        int GetOwnerToAssignToId(IList<string> commandParameters);
    }
}
