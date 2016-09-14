using System;

using Exceptions_Homework.Contracts;

namespace Exceptions_Homework.PrimeChecker
{
    public class PrimeChecker
    {
        ILogger logger;

        public PrimeChecker(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.logger = logger;
        }

        public void CheckPrime(int primeCandidate)
        {
            var primeCheckResult = this.CheckIfValueIsPrime(primeCandidate);
            this.LogIsPrimeMessage(primeCandidate, primeCheckResult);
        }

        private bool CheckIfValueIsPrime(int number)
        {
            var isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }

        private void LogIsPrimeMessage(int value, bool isPrime)
        {
            if (isPrime)
            {
                this.logger.Log($"{value} is prime.");
            }
            else
            {
                this.logger.Log($"{value} is not prime.");
            }
        }
    }
}
