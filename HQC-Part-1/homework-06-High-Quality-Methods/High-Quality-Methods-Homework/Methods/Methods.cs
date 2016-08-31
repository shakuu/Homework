using System;
using System.Collections.Generic;

namespace Methods
{
    internal class Methods
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

        internal static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                return -1;
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        internal static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        internal static double CalcDistance(double x1, double y1, double x2, double y2,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
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
