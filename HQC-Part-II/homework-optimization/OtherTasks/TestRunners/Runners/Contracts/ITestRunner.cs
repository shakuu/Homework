using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Runners.Contracts
{
    public interface ITestRunner
    {
        void RunTest(ITestContainer testsToRunContainer);

        IEnumerable<string> LogEntries { get; }
    }
}
