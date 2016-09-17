using System;
using System.Collections.Generic;

namespace TestRunners.Tests.Contracts
{
    public interface ITestContainer
    {
        int NumberOfRuns { get; }
        
        IEnumerable<Action> Tests { get; }
    }
}
