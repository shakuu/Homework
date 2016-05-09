using System;
using System.Globalization;

namespace _01_Leap_Year
{
    class LeapYear
    {
        static void Main(string[] args)
        {
            // https://support.microsoft.com/en-us/kb/214019
            // how to determine if it s a leap year

            DateTime Year = DateTime.ParseExact
                            (
                                Console.ReadLine(),            // string -> input string 
                                "yyyy",                        // format -> 4 digit year
                                CultureInfo.InvariantCulture   // invariant culture
                            );

            //int Year = int.Parse(Console.ReadLine());        // alternatively read as int
            bool isLeap = false;

            // ouput 
            string Win = "Leap";
            string notWin = "Common";

            // Step 1
            if (Year.Year % 4 == 0)
            {
                // Step 2
                if (Year.Year % 100 == 0)
                {
                    // step 3
                    if (Year.Year % 400 == 0)
                    {
                        isLeap = true;
                    }
                    else
                    {
                        // false
                    }
                }
                else
                {
                    isLeap = true;
                }
            }
            else
            {
                // false
            }

            if (isLeap)
            {
                Console.WriteLine(Win);
            }
            else
            {
                Console.WriteLine(notWin);
            }
        }
    }
}
