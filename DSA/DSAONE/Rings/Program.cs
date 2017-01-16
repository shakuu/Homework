using System;
using System.Numerics;

namespace Rings
{
    class Program
    {
        private static BigInteger[] factorials = new BigInteger[21];

        static void Main(string[] args)
        {
            factorials[0] = 1;
            factorials[1] = 1;
            factorials[2] = 2;
            factorials[3] = 6;
            factorials[4] = 24;
            factorials[5] = 120;
            factorials[6] = 720;
            factorials[19] = 121645100408832000;
            factorials[20] = 2432902008176640000;

            var ringsCount = int.Parse(Console.ReadLine());
            var ringsChildren = new int[ringsCount + 1];

            for (int i = 0; i < ringsCount; i++)
            {
                var parent = int.Parse(Console.ReadLine());
                ringsChildren[parent]++;
            }

            BigInteger possible = 1;
            foreach (var ring in ringsChildren)
            {
                possible *= CalcFactorial(ring);
            }

            Console.WriteLine(possible);
        }

        private static BigInteger CalcFactorial(int n)
        {
            if (factorials[n] != 0)
            {
                return factorials[n];
            }

            if (n == 0)
            {
                return 1;
            }

            var factorial = n * CalcFactorial(n - 1);
            factorials[n] = factorial;

            return factorial;
        }
    }
}
