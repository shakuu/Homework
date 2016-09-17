using System;
using System.Collections.Generic;
using System.Diagnostics;

using TestRunners.Runners.Contracts;
using TestRunners.Tests.Contracts;
using TestRunners.Utils.Conctracts;

namespace TestRunners.Runners
{
    public class NaiveTestRunner : ITestRunner
    {
        private const string LogEntryFormat = "{1, 16} - {2, 6:F2} - {3, 6:F2}";

        private ICollection<string> logEntries;

        public NaiveTestRunner()
        {
            this.logEntries = new LinkedList<string>();
        }

        public IEnumerable<string> LogEntries
        {
            get
            {
                var exposedLogEntries = new List<string>(this.logEntries);
                return exposedLogEntries;
            }
        }

        public void RunTest(ITestContainer testsToRunContainer)
        {
            if (testsToRunContainer == null)
            {
                throw new ArgumentNullException("testsToRun");
            }

            foreach (var test in testsToRunContainer.Tests)
            {
                var totalTime = this.Test(test, testsToRunContainer.NumberOfRuns);
            }
        }

        private long Test(Action task, int numberOfRuns)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int run = 0; run < numberOfRuns; run++)
            {
                task.Invoke();
            }

            stopwatch.Stop();
            var totalTimeElapsedInMs = stopwatch.ElapsedMilliseconds;
            return totalTimeElapsedInMs;
        }

        private void Log(string testName, long totalTimeElapsedInMs, int numberOfRuns)
        {
            var averageTimeElapsedInMs = totalTimeElapsedInMs / numberOfRuns;

            var logEntry = string.Format(
                NaiveTestRunner.LogEntryFormat,
                testName,
                totalTimeElapsedInMs,
                averageTimeElapsedInMs);

            this.logEntries.Add(logEntry);
        }
    }
}
