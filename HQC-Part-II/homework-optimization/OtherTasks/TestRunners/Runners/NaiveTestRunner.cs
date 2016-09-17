using System;
using System.Collections.Generic;
using System.Diagnostics;

using TestRunners.Runners.Contracts;
using TestRunners.Tests.Contracts;

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

        public void EvaluateTests(ITestContainer testsToRunContainer)
        {
            if (testsToRunContainer == null)
            {
                throw new ArgumentNullException("testsToRun");
            }

            var numberOfRuns = testsToRunContainer.NumberOfRuns;
            foreach (var test in testsToRunContainer.Tests)
            {
                var totalTimeElapsedInMs = this.MeasureTestExecutionTime(test, numberOfRuns);

                var testName = test.Method.Name;
                this.CreateNewLogEntry(testName, totalTimeElapsedInMs, numberOfRuns);
            }

            this.CreateNewEmptyLogEntry();
        }

        private long MeasureTestExecutionTime(Action task, int numberOfRuns)
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

        private void CreateNewLogEntry(string testName, long totalTimeElapsedInMs, int numberOfRuns)
        {
            var averageTimeElapsedInMs = totalTimeElapsedInMs / numberOfRuns;

            var logEntry = string.Format(
                NaiveTestRunner.LogEntryFormat,
                testName,
                totalTimeElapsedInMs,
                averageTimeElapsedInMs);

            this.logEntries.Add(logEntry);
        }

        private void CreateNewEmptyLogEntry()
        {
            this.logEntries.Add(Environment.NewLine);
        }
    }
}
