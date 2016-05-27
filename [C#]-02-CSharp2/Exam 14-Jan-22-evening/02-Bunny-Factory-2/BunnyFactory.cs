
namespace _02_Bunny_Factory_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    class BunnyFactory
    {
        static void Main()
        {
            var factoryb = new StringBuilder();

            while (true)
            {
                var digit = Console.ReadLine();

                if (digit == "END") break;

                if (int.Parse(digit) > 1 ) factoryb.Append(digit);
            }

            var cagesToSum = 0;

            var factory = factoryb.ToString();

            while (true)
            {
                // Break if not enough cages
                if (factory.Length < ++cagesToSum) break;

                var cagesToProcess = 0;

                for (int cage = 0; cage < cagesToSum; cage++)
                {
                    cagesToProcess += int.Parse(factory[cage].ToString());
                }

                // Break if not enough cages.
                if (factory.Length < cagesToProcess + cagesToSum) break;

                // Remove the cages used so far
                factory = factory.Remove(0, cagesToSum);

                BigInteger cageSum = 0;
                BigInteger cageProduct = 1;


                for (int cage = 0; cage < cagesToProcess; cage++)
                {
                    var cageValue = int.Parse(factory[cage].ToString());

                    cageSum += cageValue;
                    cageProduct *= cageValue;
                }

                // Remove the cages used so far
                factory = factory.Remove(0, cagesToProcess);

                factory = factory.Insert(0, cageProduct.ToString());
                factory = factory.Insert(0, cageSum.ToString());

                for (int cage = factory.Length - 1; cage >= 0; cage--)
                {
                    var cageValue = int.Parse(factory[cage].ToString());

                    if (cageValue < 2) factory = factory.Remove(cage, 1);
                }
            }

            Console.WriteLine(string.Join(" ", factory.ToString().ToCharArray()));
        }
    }
}
