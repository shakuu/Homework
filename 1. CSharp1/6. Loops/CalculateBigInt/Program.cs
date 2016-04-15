using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Calculate2
{
    class CalculateTrue
    {
        static void Main()
        {
            int numbN = int.Parse(Console.ReadLine());
            decimal numbX = decimal.Parse(Console.ReadLine());

            decimal[] resultsTop = new decimal [numbN + 1];
            resultsTop[0] = 1;
            decimal[] resultsBot = new decimal[numbN + 1];
            resultsBot[0] = 1;
            //ORIGNAL
            unchecked
            {
                for (int index = 1; index < numbN + 1; index++)
                {
                    resultsTop[index] = resultsTop[index - 1] * index;
                    resultsBot[index] = resultsBot[index - 1] * numbX;
                    // resultsTop[index] = resultsTop[index - 1] * index / numbX;

                }
            }

            decimal endResult = 0;
            for (int index = 0; index < numbN + 1; index++)
            {
                endResult += resultsTop[index] / resultsBot[index];
                // resultsTop[index] = resultsTop[index - 1] * index / numbX;

            }
            Console.WriteLine("{0,0:f5}", endResult);
        }
    }
}
