using System;
using System.Collections.Generic;

using FastAndFurious.ConsoleApplication.Engine.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public abstract class AssigningCommand : ICommand, IAssigningCommand
    {
        public int GetObjectToAssignId(IList<string> commandParameters)
        {
            return int.Parse(commandParameters[2]);
        }

        public int GetOwnerToAssignToId(IList<string> commandParameters)
        {
            return int.Parse(commandParameters[5]);
        }

        public abstract void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections);

        public abstract bool IsCommand(IList<string> commandParameters);
    }
}
