using System;
using System.Text;

namespace _02_Reverse_String
{
    class Program
    {
        static void Main()
        {
            var toReverse = Console.ReadLine();

            StringBuilder ReverseInput = 
                new StringBuilder(toReverse.Length);

            foreach (var Letter in toReverse)
            {
                ReverseInput.Insert(0, Letter);
            }

            Console.WriteLine(ReverseInput);
        }
    }
}
