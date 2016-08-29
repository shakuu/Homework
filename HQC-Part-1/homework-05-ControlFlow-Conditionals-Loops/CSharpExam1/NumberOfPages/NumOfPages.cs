using System;

namespace NumberOfPages
{
    public class NumOfPages
    {
        public static void Main()
        {
            var digitsCount = int.Parse(Console.ReadLine());

            var digitsPerPageNumber = 1;
            var maximumPagesWithDigitsPerPageNumber = 9;

            var pagesCount = 0;
            while (digitsCount > 0)
            {
                if (digitsCount <= maximumPagesWithDigitsPerPageNumber * digitsPerPageNumber)
                {
                    pagesCount += digitsCount / digitsPerPageNumber;
                    digitsCount -= digitsCount;
                }
                else if (digitsCount > maximumPagesWithDigitsPerPageNumber * digitsPerPageNumber)
                {
                    pagesCount += maximumPagesWithDigitsPerPageNumber;
                    digitsCount -= maximumPagesWithDigitsPerPageNumber * digitsPerPageNumber;
                }

                digitsPerPageNumber++;
                maximumPagesWithDigitsPerPageNumber *= 10;
            }

            Console.WriteLine(pagesCount);
        }
    }
}