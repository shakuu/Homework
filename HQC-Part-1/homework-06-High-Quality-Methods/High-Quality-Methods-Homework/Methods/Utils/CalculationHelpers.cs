using System;
using System.Collections.Generic;

namespace Methods.Utils
{
    internal class CalculationHelpers
    {
        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            var isValidTriangle = CheckIfSideLengthsCanComposeAValidTriangle(a, b, c);
            if (!isValidTriangle)
            {
                throw new ArgumentException("Sides are of invalid length.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double areaSqr = halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c);
            double area = Math.Sqrt(areaSqr);
            return area;
        }

        internal static string DigitToWord(int number)
        {
            var digitTranslations = new Dictionary<int, string>()
            {
                { 0, "zero"  },
                { 1, "one"   },
                { 2, "two"   },
                { 3, "three" },
                { 4, "four"  },
                { 5, "five"  },
                { 6, "six"   },
                { 7, "sevem" },
                { 8, "eight" },
                { 9, "nine"  }
            };

            string result;
            if (digitTranslations.ContainsKey(number))
            {
                result = digitTranslations[number];
            }
            else
            {
                throw new ArgumentException("Number is not a digit.");
            }

            return result;
        }

        internal static int FindMaximumValue(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No elements to evaluate.");
            }

            var maximumValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (maximumValue < elements[i])
                {
                    maximumValue = elements[i];
                }
            }

            return maximumValue;
        }

        internal static void PrintToConsoleAsNumberInFormat(object number, string format)
        {
            if (number == null || format == null)
            {
                throw new ArgumentNullException("Null input.");
            }

            decimal parsedNumber;
            var isParsed = decimal.TryParse(number.ToString(), out parsedNumber);
            if (!isParsed)
            {
                throw new ArgumentException("Invalid number.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format string.");
            }
        }


        internal static double CalculateDistance(double xPointA, double yPointA, double xPointB, double yPointB,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (yPointA == yPointB);
            isVertical = (xPointA == xPointB);

            var distanceX = xPointB - xPointA;
            var distanceY = yPointB - yPointA;

            var distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            return distance;
        }

        private static bool CheckIfSideLengthsCanComposeAValidTriangle(double sideA, double sideB, double sideC)
        {
            var isSideAValid = sideA < (sideB + sideC);
            var isSideBValid = sideB < (sideA + sideC);
            var isSideCValid = sideC < (sideA + sideB);
            var isValidTriangle = isSideAValid && isSideBValid && isSideCValid;

            return isValidTriangle;
        }
    }
}
