

namespace _02_Bunny_Factory_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    class BunnyFactoryListInput
    {
        static void Main()
        {
            var factory = new List<int>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END") break;

                factory.Add(int.Parse(line));
            }

            var factoryIteration = 1;

            while (true)
            {
                if (factory.Count() < factoryIteration) break;

                var cagesToProcess = 0;

                for (int cage = 0; cage < factoryIteration; cage++)
                {
                    cagesToProcess += factory[cage];
                }

                if (factory.Count() < cagesToProcess + factoryIteration) break;

                for (int cage = 0; cage < factoryIteration; cage++) factory.RemoveAt(0);

                BigInteger cageSum = 0;
                BigInteger cageProduct = 1;

                for (int cage = 0; cage < cagesToProcess; cage++)
                {
                    cageSum += factory[cage];
                    cageProduct *= factory[cage];
                }

                for (int cage = 0; cage < cagesToProcess; cage++) factory.RemoveAt(0);

                var newFactory = new StringBuilder();

                newFactory.Append(cageSum);
                newFactory.Append(cageProduct);
                newFactory.Append(string.Join("", factory));

                factory = newFactory
                    .ToString()
                    .ToCharArray()
                    .Select(x => int.Parse(x.ToString()))
                    .Where(x => x > 1)
                    .ToList();

                factoryIteration++;
            }

            Console.WriteLine(string.Join(" ", factory));
        }
    }
}

