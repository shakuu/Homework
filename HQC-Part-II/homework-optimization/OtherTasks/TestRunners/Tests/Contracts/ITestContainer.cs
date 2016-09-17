using System;
using System.Collections.Generic;

namespace TestRunners.Tests.Contracts
{
    public interface ITestContainer
    {
        int NumberOfRuns { get; }

        IEnumerable<string> TestNames { get; }

        IEnumerable<Action> Tests { get; }
    }
}
