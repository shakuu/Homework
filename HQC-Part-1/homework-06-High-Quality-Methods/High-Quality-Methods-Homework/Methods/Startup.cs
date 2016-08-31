using System;

using Methods.OtherInfo;
using Methods.Students;
using Methods.Utils;

namespace Methods
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(CalculationHelpers.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(CalculationHelpers.DigitToWord(5));

            Console.WriteLine(CalculationHelpers.FindMaximumValue(5, -1, 3, 2, 14, 2, 3));

            CalculationHelpers.PrintToConsoleAsNumberInFormat(1.3, "f");
            CalculationHelpers.PrintToConsoleAsNumberInFormat(0.75, "%");
            CalculationHelpers.PrintToConsoleAsNumberInFormat(2.30, "r");

            bool horizontal;
            bool vertical;
            Console.WriteLine(CalculationHelpers.CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            var peterOtherInfo = new OtherInformation("From Sofia, born on 17.03.1992");
            Student peter = new Student("Peter", "Ivanov", peterOtherInfo);

            var stellaOtherInfo = new OtherInformation("From Vidin, gamer, high results, born on 03.11.1993");
            Student stella = new Student("Stella", "Markova", stellaOtherInfo);

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
