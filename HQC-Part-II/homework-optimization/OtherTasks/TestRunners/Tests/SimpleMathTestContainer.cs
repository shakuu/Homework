using System;
using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Tests
{
    public class SimpleMathTestContainer<T> : ITestContainer
    {
        private int numberOfRuns;
        private IEnumerable<Action> tests;

        private dynamic valueA;
        private dynamic valueB;

        public SimpleMathTestContainer(T valueA, T valueB, int numberOfRuns)
        {
            this.numberOfRuns = numberOfRuns;
            this.tests = this.InitializeTestCollection();
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

        public IEnumerable<Action> Tests
        {
            get
            {
                var exposedTests = new LinkedList<Action>(this.tests);
                return exposedTests;
            }
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
