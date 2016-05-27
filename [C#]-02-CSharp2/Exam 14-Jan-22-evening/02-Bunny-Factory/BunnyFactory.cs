namespace _02_Bunny_Factory
{
    using System;
    using System.Text;
    using System.Numerics;

    class BunnyFactory
    {
        // Helper variables.
        static StringBuilder factory;

        static int chrToDig = '0';

        static void Input()
        {
            var END = "END";

            factory = new StringBuilder();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == END) break;

                factory.Append(line);
            }
        }

        static void Output()
        {
            var output = factory.ToString().ToCharArray();

            Console.WriteLine(string.Join(" ", output));
        }

        static void MainLogic()
        {
            // Sum + 1 more cage each factory cycle
            // Take Sum number of cages and find their sum and prodcut
            // Remove all digits ( cages ) used in the process and insert the result
            // Concat the rest, Break if not enough cages.

            var cagesToSum = 1;

            while (true)
            {
                // Sum + 1 more cage each factory cycle
                if (factory.Length < cagesToSum) break;
               
                // Sum cagesToSum cages
                var numberOfCages = 0;

                for (int cage = 0; cage < cagesToSum; cage++)
                {
                    numberOfCages += factory[cage] - chrToDig;
                }

                // If not enough cages left
                // close the factory down.
                if (factory.Length < numberOfCages + cagesToSum) break;

                // Remove used cages
                factory.Remove(0, cagesToSum);

                // Find the Sum and Product and 
                // insert them at the start of the Factory
                // Sum + Product + Whatever else
                // Product first
                var curProduct = new StringBuilder().Append(FindProduct(numberOfCages));
                var curSum = new StringBuilder(FindSum(numberOfCages));

                CleanCages(ref curProduct);
                CleanCages(ref curSum);

                // Remove the cages just used up.
                factory.Remove(0, numberOfCages);

                // Add the new strings
                factory.Insert(0, curProduct);
                factory.Insert(0, curSum);

                ++cagesToSum;
            }
        }

        static void CleanCages(ref StringBuilder cages)
        {

            for (int cage = cages.Length - 1; cage >= 0; cage--)
            {
                if (cages[cage] == '0' || cages[cage] == '1')
                {
                    cages.Remove(cage, 1);
                }
            }
        }

        static string FindProduct(int numberOfCages)
        {
            BigInteger cageProduct = 1;

            for (int cage = 0; cage < numberOfCages; cage++)
            {
                cageProduct *= factory[cage] - chrToDig;
            }

            return cageProduct.ToString();
        }

        static string FindSum(int numberOfCages)
        {
            BigInteger cageSum = 0;

            for (int cage = 0; cage < numberOfCages; cage++)
            {
                cageSum += factory[cage] - chrToDig;
            }

            return cageSum.ToString();
        }

        static void Main()
        {
            Input();
            MainLogic();
            Output();
        }
    }
}