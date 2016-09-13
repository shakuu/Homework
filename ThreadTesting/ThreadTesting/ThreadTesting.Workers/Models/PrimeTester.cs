using System;

using ThreadTesting.Workers.Contracts;

namespace ThreadTesting.Workers.Models
{
    public class PrimeTester : ITester
    {
        private int primeCandidate;
        private bool? isPassing;
        private bool isTested;

        public PrimeTester(int primeCandidate)
        {
            this.primeCandidate = primeCandidate;
            this.isPassing = null;
            this.isTested = false;
        }

        public string Value
        {
            get
            {
                return this.primeCandidate.ToString();
            }
        }

        public bool? IsPassing
        {
            get
            {
                return this.isPassing;
            }
        }

        public void RunTest()
        {
            if (this.isTested)
            {
                return;
            }
            else
            {
                this.isPassing = this.ExecutePrimeTest(this.primeCandidate);
                this.isTested = true;
            }
        }

        private bool? ExecutePrimeTest(int primeCandidate)
        {
            bool? isPassing = null;
            var primeCandidateSqrt = Math.Sqrt(primeCandidate);
            var maximumDivisor = (int)Math.Floor(primeCandidateSqrt);
            var minimumDivisor = 2;
            for (int divisor = minimumDivisor; divisor <= maximumDivisor; divisor++)
            {
                if (primeCandidate % divisor == 0)
                {
                    isPassing = false;
                    break;
                }
            }

            isPassing = isPassing == null ? true : isPassing;
            return isPassing;
        }
    }
}
