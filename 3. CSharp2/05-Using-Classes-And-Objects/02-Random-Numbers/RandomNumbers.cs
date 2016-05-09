using System;

namespace _02_Random_Numbers
{
    class RandomNumbers
    {
        static void Main()
        {
            Random Randomizer = new Random();

            for (int Line = 0; Line < 10; Line++)
            {
                Console.WriteLine(Randomizer.Next(100, 200));
            }
        }
    }
}
