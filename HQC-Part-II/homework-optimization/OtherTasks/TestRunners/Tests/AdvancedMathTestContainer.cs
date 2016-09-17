using System;
using System.Collections.Generic;

using TestRunners.Tests.Abstract;

namespace TestRunners.Tests
{
    public class AdvancedMathTestContainer<T> : AbstractTestContainer<T>
    {
        public AdvancedMathTestContainer(int numberOfRuns)
            : base(numberOfRuns)
        {
        }

        protected override string CreateContainerName(Type type)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Action> InitializeTestCollection()
        {
            throw new NotImplementedException();
        }
    }
}
