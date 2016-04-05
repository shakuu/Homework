using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRug
{
    class Program
    {
        static void Main(string[] args)
        {
            int rugSize = int.Parse(Console.ReadLine());
            int xSize = int.Parse(Console.ReadLine());

            char[,] rug = new char[3 * xSize + 4, 2 * rugSize + 1];
            string[] xPrint = new string[xSize+2];
            string[] xPrintSides = new string[4];

            //code # 0 , X 1, \ 2, / 3
            //Build X strings
            //mid row
            for ( int i = 0; i < xSize; i++)
            {
                xPrint[(xSize + 1)/ 2] += "#";
            }
            xPrint[(xSize +1)/2] = xPrint[(xSize + 1)/ 2].Insert(0, "1");
            xPrint[(xSize + 1) / 2] +="1";
            //mid row
            //top mid
            for ( int i = 1, x=xSize-1; i< (xSize+1)/2; i++, x-=2)
            {
                for ( int p = 0; p<xSize+x; p++)
                {
                    xPrint[i] += "#";
                }
                xPrint[i] = "2" + xPrint[i] + "3";
            }
            // bot mid
            for (int i = (xSize+1)/2+1, x = 2; i < ((xSize + 1) / 2 + 1) +(xSize-1)/2; i++, x += 2)
            {
                for (int p = 0; p < xSize + x; p++)
                {
                    xPrint[i] += "#";
                }
                xPrint[i] = "3" + xPrint[i] + "2";
            }
            //midX 
            for( int i = 0; i< xSize*2+1; i++)
            {
                if ( i == xSize)
                {
                    xPrint[0] += "1";
                    xPrint[xSize + 1] += "1";
                }
                else
                {
                    xPrint[0] += "#";
                    xPrint[xSize + 1] += "#";
                }
            }
            xPrint[0] = "2" + xPrint[0] + "3";
            xPrint[xSize+1] = "3" + xPrint[xSize + 1] + "2";
            //end mid
            //sides
            for ( int i = 0; i < xSize; i++)
            {
                xPrintSides[0] += "#";
                xPrintSides[1] += "#";
                xPrintSides[2] += "#";
                xPrintSides[3] += "#";
            }
            xPrintSides[0] = "2" + xPrintSides[0] + "3";
            xPrintSides[1] = "2" + xPrintSides[1] + "3";
            xPrintSides[2] = "3" + xPrintSides[2] + "2";
            xPrintSides[3] = "3" + xPrintSides[3] + "2";

            //test
            foreach ( var str in xPrint)
            {
                Console.WriteLine(str);
            }
            foreach(var str in xPrintSides)
            {
                Console.WriteLine(str);
            }

        }
    }
}
