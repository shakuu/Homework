using System;

using Methods.Students;

namespace Methods
{
    public class Startup
    {
        static void Main()
        {
            Console.WriteLine(Utilities.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(Utilities.DigitToWord(5));

            Console.WriteLine(Utilities.FindMaximumValue(5, -1, 3, 2, 14, 2, 3));

            Utilities.PrintToConsoleAsNumberInFormat(1.3, "f");
            Utilities.PrintToConsoleAsNumberInFormat(0.75, "%");
            Utilities.PrintToConsoleAsNumberInFormat(2.30, "r");

            bool horizontal;
            bool vertical;
            Console.WriteLine(Utilities.CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            //Student peter = new Student("Peter", "Ivanov", "From Sofia, born on 17.03.1992");
            //Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born on 03.11.1993");

            //Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
