using System;
using System.Collections.Generic;

using TestRunners.Tests.Abstract;

namespace TestRunners.Tests
{
    public class SimpleMathTestContainer<T> : AbstractTestContainer<T>
    {
        private dynamic valueA;
        private dynamic valueB;

        public SimpleMathTestContainer(T valueA, T valueB, int numberOfRuns)
            : base(numberOfRuns)
        {
            this.valueA = valueA;
            this.valueB = valueB;
        }

        protected override IEnumerable<Action> InitializeTestCollection()
        {
            var tests = new LinkedList<Action>();
            tests.AddLast(this.AddTest);
            tests.AddLast(this.SubtractTest);
            tests.AddLast(this.IncrementTest);
            tests.AddLast(this.MultiplyTest);
            tests.AddLast(this.DivideTest);

            return tests;
        }

        protected override string CreateContainerName(Type type)
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
