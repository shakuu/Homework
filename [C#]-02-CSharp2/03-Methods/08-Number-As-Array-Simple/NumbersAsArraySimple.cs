using System;

namespace _08_Number_As_Array_Simple
{
    class NumbersAsArraySimple
    {
        static void Main()
        {
            // input
            Console.ReadLine();     // input line 1 array size

            // Convert input lines to numbers and add them
            // Convert ouput to require output

            string NumberOne = Console.ReadLine();
            string NumberTwo = Console.ReadLine();

            // find the sum
            int Result = GetNumber(NumberOne) + GetNumber(NumberTwo);

            //output
            Console.WriteLine(GetString(Result));

        }

        public static int GetNumber(string InputFormat)
        {
            string tempString = "";

            InputFormat = InputFormat.Replace(" ", "");

            for (int digit = InputFormat.Length - 1;
                     digit >= 0;
                     digit--)
            {
                tempString += InputFormat[digit];
            }

            return int.Parse(tempString);
        }

        public static string GetString(int Number)
        {
            string OutputFormat = "";

            string NumToString = Number.ToString();

            for (int digit = NumToString.Length - 1;
                     digit >= 0; 
                     digit--)
            {
                OutputFormat += NumToString[digit];
                OutputFormat += " ";
            }

            OutputFormat = OutputFormat.TrimEnd(' ');

            return OutputFormat;
        }
    }
}
