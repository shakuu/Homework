using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Runners.Contracts
{
    public interface ITestRunner
    {
        void EvaluateTests(ITestContainer testsToRunContainer);

        IEnumerable<string> LogEntries { get; }
    }
}
