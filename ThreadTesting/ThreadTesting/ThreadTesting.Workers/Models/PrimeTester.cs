using System;

using ThreadTesting.Workers.Contracts;

namespace ThreadTesting.Workers.Models
{
    public class PrimeTester : ITester
    {
        private int primeCandidate;
        private bool isPassing;
        private bool isTested;

        public PrimeTester(int primeCandidate)
        {
            this.primeCandidate = primeCandidate;
            this.isPassing = true;
            this.isTested = false;
        }

        public bool? IsPassing
        {
            get
            {
                if (this.isTested)
                {
                    return this.isPassing;
                }
                else
                {
                    return null;
                }
            }
        }

        public void RunTest()
        {
            if (this.isTested)
            {
                return;
            }

            var primeCandidateSqrt = Math.Sqrt(this.primeCandidate);
            var maximumDivisor = (int)Math.Floor(primeCandidateSqrt);
            var minimumDivisor = 2;
            for (int divisor = minimumDivisor; divisor <= maximumDivisor; divisor++)
            {
                if (this.primeCandidate % divisor == 0)
                {
                    this.isPassing = false;
                    break;
                }
            }

            this.isTested = true;
        }
    }
}
