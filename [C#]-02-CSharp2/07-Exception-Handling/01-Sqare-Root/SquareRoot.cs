using System;

namespace _01_Sqare_Root
{
    class SquareRoot
    {
        static void Main()
        {
            // Output strings
            var byebye = "Good bye";
            var error = "Invalid number";

            try
            {
                var input = double.Parse(Console.ReadLine());
                var sqrt = Math.Sqrt(input).ToString("F3");

                if (sqrt == "NaN")
                {
                    throw new System.FormatException();
                }
                else
                {
                    Console.WriteLine(sqrt);
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine(error);
            }
            finally
            {
                Console.WriteLine(byebye);
            }            
        }
    }
}
