using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Runners.Contracts
{
    public interface ITestRunner
    {
        IEnumerable<string> LogEntries { get; }

        void WarmUp(int numberOfRuns);

        void EvaluateTests(ITestContainer testsToRunContainer);
    }
}
