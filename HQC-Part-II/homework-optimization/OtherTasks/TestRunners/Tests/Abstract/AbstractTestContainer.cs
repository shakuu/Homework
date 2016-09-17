using System;
using System.Collections.Generic;

using TestRunners.Tests.Contracts;

namespace TestRunners.Tests.Abstract
{
    public abstract class AbstractTestContainer<T> : ITestContainer
    {
        private int numberOfRuns;
        private string containerName;
        private IEnumerable<Action> tests;

        public AbstractTestContainer(int numberOfRuns)
        {
            this.numberOfRuns = numberOfRuns;
            this.tests = this.InitializeTestCollection();
            this.containerName = this.CreateContainerName(typeof(T));
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

        protected abstract IEnumerable<Action> InitializeTestCollection();

        protected abstract string CreateContainerName(Type type);
    }
}
