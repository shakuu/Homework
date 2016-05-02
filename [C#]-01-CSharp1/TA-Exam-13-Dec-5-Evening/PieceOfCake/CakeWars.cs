using System;

namespace PieceOfCake
{
    class CakeWars
    {
        static void Main()
        {
            // input A B C D -> A/B C/D
            decimal numA = decimal.Parse(Console.ReadLine());   // Nom Cake 1
            decimal numB = decimal.Parse(Console.ReadLine());   // Denom Cake 1
            decimal numC = decimal.Parse(Console.ReadLine());   // Nom Cake 2
            decimal numD = decimal.Parse(Console.ReadLine());   // Denom Cake 2

            // Get the Same Denom
            decimal temp = numB;

            numA *= numD;
            numB *= numD;

            numC *= temp;
            numD *= temp;

            //Print
            //Case 1: division > 1
            if ((numA+numC)/numB > 1)
            {
                Console.WriteLine((int)((numA + numC) / numB));
                Console.WriteLine("{0}/{1}", numA + numC, numB);
            }
            // Case 2: division < 1
            else
            {
                Console.WriteLine(((numA + numC) / numB).ToString("f22"));
                Console.WriteLine("{0}/{1}", numA + numC, numB);
            }
        }
    }
}
