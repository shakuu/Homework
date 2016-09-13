using System.Collections.Generic;

namespace ThreadTesting.Workers.Contracts
{
    public interface IRangeTester
    {
        bool TestsAreRunning { get; }

        void RunTests();

        IEnumerable<string> GetUpdatedRange();
    }
}
