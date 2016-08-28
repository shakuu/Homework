using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfPages
{
    class NumOfPages
    {
        static void Main()
        {

            //input 
            int numOfDigits = int.Parse(Console.ReadLine());

            //variables
            int pagesPerDigit = 1;
            int maxPages = 9;

            int pageCount = 0;

            while (numOfDigits > 0)
            {
                if (numOfDigits <= maxPages * pagesPerDigit)
                {
                    pageCount += numOfDigits / pagesPerDigit;
                    numOfDigits -= numOfDigits;
                }
                else if (numOfDigits > maxPages * pagesPerDigit)
                {

                    pageCount += maxPages;
                    numOfDigits -= maxPages * pagesPerDigit;
                }

                pagesPerDigit++;
                maxPages *= 10;
            }

            Console.WriteLine(pageCount);
        }
    }
}
