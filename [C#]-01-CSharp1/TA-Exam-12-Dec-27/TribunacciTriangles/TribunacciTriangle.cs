using System;
using System.Collections.Generic;

namespace TribunacciTriangles
{
    class TribunacciTriangle
    {
        static void Main()
        {
            List<long> Triangle = new List<long>();
            //input
            Triangle.Add(long.Parse(Console.ReadLine()));
            Triangle.Add(long.Parse(Console.ReadLine()));
            Triangle.Add(long.Parse(Console.ReadLine()));
            int inputLength = int.Parse(Console.ReadLine());

            //build a list of numbers
            int triangleLength = 0;
            for (int i =0; i< inputLength;i++ )
            {
                triangleLength += inputLength- i;
            }

            for (int i = 3; i < triangleLength; i++)
            {
                Triangle.Add(Triangle[i - 1] + Triangle[i - 2] + Triangle[i - 3]);
            }

            int counter = 0;
            string toPrint;
            for (int row = 1; row <= inputLength; row++)
            {
                //clear the string
                toPrint = "";
                //build the string 
                for (int i = 0; i < row; i++)
                {
                    toPrint += Triangle[counter].ToString();
                    counter++;
                    if (i != row - 1)
                    {
                        toPrint += " ";
                    }
                }
                Console.WriteLine(toPrint);
            }
        }
    }
}
