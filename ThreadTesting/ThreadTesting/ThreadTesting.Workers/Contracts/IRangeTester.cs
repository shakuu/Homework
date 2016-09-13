using System.Collections.Generic;

namespace ThreadTesting.Workers.Contracts
{
    public interface IRangeTester<T>
    {
        bool TestsAreRunning { get; }

        void TestRange(T min, T max);

        IEnumerable<T> GetUpdatedRange();
    }
}
