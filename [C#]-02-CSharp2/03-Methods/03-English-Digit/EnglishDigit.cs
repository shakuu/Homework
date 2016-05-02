using System;

namespace _03_English_Digit
{
    class EnglishDigit
    {
        static void Main()
        {
            //input
            int inputNumber = int.Parse(Console.ReadLine());

            // output
            Console.WriteLine(GetTheWord(inputNumber));
        }

        public static string GetTheWord(int Number)
        {
            // split the names of digits into an array for easy access
            string[] Words = "zero one two three four five six seven eight nine".Split(' ');

            // return the appropriate string
            return Words[Number % 10];
        }
    }
}
