using System;
using System.Collections.Generic;

using TestRunners.Tests.Abstract;

namespace TestRunners.Tests
{
    public class AdvancedMathTestContainer<T> : AbstractTestContainer<T>
    {
        private dynamic valueA;

        public AdvancedMathTestContainer(T valueA, int numberOfRuns)
            : base(numberOfRuns)
        {
            this.valueA = valueA;
        }

        protected override string CreateContainerName(Type type)
        {
            var containerName = string.Format("AdvancedMath<{0}>", type.Name);
            return containerName;
        }

        protected override IEnumerable<Action> InitializeTestCollection()
        {
            var tests = new LinkedList<Action>();
            tests.AddLast(this.SqrtTest);
            tests.AddLast(this.LogTest);
            tests.AddLast(this.SinTest);

            return tests;
        }

        private void SqrtTest()
        {
            var valueB = Math.Sqrt((double)this.valueA);
        }

        private void LogTest()
        {
            var valueB = Math.Log((double)this.valueA);
        }

        private void SinTest()
        {
            var valueB = Math.Sin((double)this.valueA);
        }
    }
}
