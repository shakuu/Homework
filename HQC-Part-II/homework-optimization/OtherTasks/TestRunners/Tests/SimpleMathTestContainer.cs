using System;
using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Tests
{
    public class SimpleMathTestContainer<T> : ITestContainer
    {
        private int numberOfRuns;
        private string containerName;
        private IEnumerable<Action> tests;

        private dynamic valueA;
        private dynamic valueB;

        public SimpleMathTestContainer(T valueA, T valueB, int numberOfRuns)
        {
            this.numberOfRuns = numberOfRuns;
            this.tests = this.InitializeTestCollection();
            this.containerName = this.CreateContainerName(typeof(T));

            this.valueA = valueA;
            this.valueB = valueB;
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

        public string TestsContainerName
        {
            get
            {
                return this.containerName;
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

        private string CreateContainerName(Type type)
        {
            var containerName = string.Format("SimpleMath<{0}>", type.Name);
            return containerName;
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
