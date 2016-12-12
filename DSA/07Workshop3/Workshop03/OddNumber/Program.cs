using System;

namespace OddNumber
{
    public class Program
    {
        public static void Main()
        {
            var numbersCount = int.Parse(Console.ReadLine());

            var number = long.Parse(Console.ReadLine());
            for (var i = 1; i < numbersCount; i++)
            {
                var next = long.Parse(Console.ReadLine());
                number ^= next;
            }

            Console.WriteLine(number);
        }
    }
}
