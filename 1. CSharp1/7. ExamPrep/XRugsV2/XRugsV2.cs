using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRugsV2
{
    class XRugsV2
    {
        static void Main()
        {
            //input
            short inputSizeRug = short.Parse(Console.ReadLine());
            short sizeX = short.Parse(Console.ReadLine());
            short sizeRug = (short)(2 * inputSizeRug + 1);
            //create empty Rug with appropriate size
            string[,] Rug = new string[sizeRug, sizeRug];

            //Fill Rug with #
            for (int x =0; x< sizeRug; x++)
            {
                for (int y = 0; y< sizeRug; y++)
                {
                    Rug[x, y] = "#";
                }
            }

            //Top section of the rug
            //Number of row to print dots on 
            int dotsToPrint = 0;
            int startPos = 0;
            for(int currRow = inputSizeRug; currRow > ((sizeX-1)/2) +1; currRow--)
            {
                dotsToPrint = (((currRow - ((sizeX - 1) / 2)) - 1) * 2) - 1;
                startPos = (sizeRug - dotsToPrint) / 2;

                Rug[startPos-1,inputSizeRug- currRow] = "\\"; //LEFT
                Rug[inputSizeRug - currRow, startPos - 1 ] = "\\"; //TOP
                Rug[startPos - 1, inputSizeRug + currRow] = "/"; //RIGHT
                Rug[inputSizeRug + currRow, startPos - 1] = "/"; //BOTTOM

                for (int dots = 0; dots < dotsToPrint; dots++)
                {
                    //LEFT
                    Rug[startPos + dots, inputSizeRug- currRow] = ".";
                    Rug[startPos + dots+1, inputSizeRug- currRow] = "/";
                    //TOP
                    Rug[inputSizeRug - currRow, startPos + dots ] = ".";
                    Rug[inputSizeRug - currRow, startPos + dots + 1] = "/";
                    //RIGHT
                    Rug[startPos + dots, inputSizeRug + currRow ] = ".";
                    Rug[startPos + dots + 1, inputSizeRug + currRow] = "\\";
                    //BOTTOM
                    Rug[inputSizeRug + currRow, startPos + dots] = ".";
                    Rug[inputSizeRug + currRow, startPos + dots + 1] = "\\";
                }

            }

            //ADD X
            try
            {
                Rug[inputSizeRug, inputSizeRug - (((sizeX - 1) / 2) + 1)] = "X";
                Rug[inputSizeRug, inputSizeRug + (((sizeX - 1) / 2) + 1)] = "X";
                Rug[inputSizeRug - (((sizeX - 1) / 2) + 1), inputSizeRug] = "X";
                Rug[inputSizeRug + (((sizeX - 1) / 2) + 1), inputSizeRug] = "X";
            }
            catch(System.IndexOutOfRangeException)
            { }
            finally { }
            //Print Rug
            for (int x = 0; x < sizeRug; x++)
            {
                for (int y = 0; y < sizeRug; y++)
                {
                    Console.Write(Rug[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
