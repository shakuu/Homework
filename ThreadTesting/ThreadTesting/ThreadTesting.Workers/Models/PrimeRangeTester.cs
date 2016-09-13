using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using ThreadTesting.Workers.Contracts;

namespace ThreadTesting.Workers.Models
{
    public class PrimeRangeTester : IRangeTester
    {
        private ConstructorInfo testerConstructor;
        private IEnumerable<ITester> testers;
        private IEnumerable<Thread> primeTesterThreads;

        private int min;
        private int max;

        public PrimeRangeTester(int min, int max, ConstructorInfo testerConstructor)
        {
            this.min = min;
            this.max = max;
            this.testerConstructor = testerConstructor;
            this.testers = new List<ITester>();
        }

        public bool TestsAreRunning
        {
            get
            {
                var areRunning = this.primeTesterThreads.Any(thread => thread.ThreadState != ThreadState.Stopped);
                return areRunning;
            }
        }

        public void RunTests()
        {
            this.TestRange(this.min, this.max);
        }

        private void TestRange(int min, int max)
        {
            this.testers = this.CreateTesters(min, max, testerConstructor);
            this.primeTesterThreads = this.CreateTestingThreads(this.testers);

            foreach (var thread in primeTesterThreads)
            {
                thread.Start();
            }
        }

        public IEnumerable<string> GetUpdatedRange()
        {
            if (this.testers == null)
            {
                return null;
            }

            var values = new List<string>();
            foreach (var tester in this.testers)
            {
                switch (tester.IsPassing)
                {
                    case true:
                        values.Add("1");
                        break;
                    default:
                        break;
                }
            }

            return values;
        }

        private IEnumerable<ITester> CreateTesters(int min, int max, ConstructorInfo testerConstructor)
        {
            var testers = new HashSet<ITester>();
            for (int primeCandidate = min; primeCandidate <= max; primeCandidate++)
            {
                var constructorParameters = new object[] { primeCandidate };
                var tester = (ITester)testerConstructor.Invoke(constructorParameters);
                testers.Add(tester);
            }

            return testers;
        }

        private IEnumerable<Thread> CreateTestingThreads(IEnumerable<ITester> testers)
        {
            var primeTesterThreads = new HashSet<Thread>();
            foreach (var tester in testers)
            {
                var newThread = new Thread(tester.RunTest);
                primeTesterThreads.Add(newThread);
            }

            return primeTesterThreads;
        }
    }
}
