using System;

namespace Feathers
{
    public class Feathers
    {
        public static void Main()
        {
            const long EvenAverageFeathersModifier = 123123123123;
            const int OddAverageFeathersModifier = 317;

            var numberOfBirds = int.Parse(Console.ReadLine());
            var numberOfFeathers = int.Parse(Console.ReadLine());

            double averageFeathersPerBird = (double)numberOfFeathers / (double)numberOfBirds;

            double result = 0;
            if (numberOfBirds % 2 == 0)
            {
                result = averageFeathersPerBird * EvenAverageFeathersModifier;
            }
            else
            {
                result = averageFeathersPerBird / OddAverageFeathersModifier;
            }

            Console.WriteLine(result.ToString("0.0000"));
        }
    }
}
