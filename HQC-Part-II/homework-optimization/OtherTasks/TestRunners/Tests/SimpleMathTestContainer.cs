using System;
using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Tests
{
    public class SimpleMathTestContainer<T> : ITestContainer
    {
        private int numberOfRuns;
        private IEnumerable<string> testNames;
        private IEnumerable<Action> tests;

        private dynamic valueA;
        private dynamic valueB;

        public SimpleMathTestContainer(T valueA, T valueB, int numberOfRuns)
        {
            this.numberOfRuns = numberOfRuns;
            this.tests = this.InitializeTestCollection();
            this.testNames = this.InitializeTestNamesCollection();
        }

        public int NumberOfRuns
        {
            get
            {
                return this.numberOfRuns;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("NumberOfRuns");
                }

                this.numberOfRuns = value;
            }
        }

        public IEnumerable<string> TestNames
        {
            get
            {
                var exposedTestNames = new LinkedList<string>(this.testNames);
                return exposedTestNames;
            }
        }

        public IEnumerable<Action> Tests
        {
            get
            {
                var exposedTests = new LinkedList<Action>(this.tests);
                return exposedTests;
            }
        }

        private IEnumerable<string> InitializeTestNamesCollection()
        {
            var testNames = new LinkedList<string>();
            testNames.AddLast(nameof(this.AddTest));
            testNames.AddLast(nameof(this.SubtractTest));
            testNames.AddLast(nameof(this.IncrementTest));
            testNames.AddLast(nameof(this.MultiplyTest));
            testNames.AddLast(nameof(this.SubtractTest));

            return testNames;
        }

        private IEnumerable<Action> InitializeTestCollection()
        {
            var tests = new LinkedList<Action>();
            tests.AddLast(this.AddTest);
            tests.AddLast(this.SubtractTest);
            tests.AddLast(this.IncrementTest);
            tests.AddLast(this.MultiplyTest);
            tests.AddLast(this.DivideTest);

            return tests;
        }

        private void AddTest()
        {
            var valueC = this.valueA + this.valueB;
        }

        private void SubtractTest()
        {
            var valueC = this.valueA - this.valueB;
        }

        private void IncrementTest()
        {
            var valueC = this.valueA++;
        }

        private void MultiplyTest()
        {
            var valueC = this.valueA * this.valueB;
        }

        private void DivideTest()
        {
            var valueC = this.valueA / this.valueB;
        }
    }
}
