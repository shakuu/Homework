using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class Calculate
    {
        static void Main()
        {
            int numbN = int.Parse(Console.ReadLine());
            double numbX = double.Parse(Console.ReadLine());
            double Solution = 1;
            double temp = 2;
            double result = 1;

            unchecked
            {

                for (int indexN = 1; indexN < numbN + 1; indexN++)
                {
                    switch (indexN)
                    {
                        case 1:
                            temp = 1 / numbX;
                            break;
                        case 2:
                            temp = (1 * 2) / Math.Pow(numbX, 2);
                            break;
                        case 3:
                            temp = (1 * 2 * 3) / Math.Pow(numbX, 3);
                            break;
                        case 4:
                            temp = (1 * 2 * 3 * 4) / Math.Pow(numbX, 4);
                            break;
                        case 5:
                            temp = (1 * 2 * 3 * 4 * 5) / Math.Pow(numbX, 5);
                            break;
                        case 6:
                            temp = (1 * 2 * 3 * 4 * 5 * 6) / Math.Pow(numbX, 6);
                            break;
                        case 7:
                            temp = (1 * 2 * 3 * 4 * 5 * 6 * 7) / Math.Pow(numbX, 7);
                            break;
                        case 8:
                            temp = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8) / Math.Pow(numbX, 8);
                            break;
                        case 9:
                            temp = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9) / Math.Pow(numbX, 9);
                            break;
                        case 10:
                            temp = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10) / Math.Pow(numbX, 10);
                            break;
                        case 11:
                            temp = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11) / Math.Pow(numbX, 11);
                            break;
                        case 12:
                            temp = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11 * 12) / Math.Pow(numbX, 12);
                            break;
                        case 13:
                            UInt64 temp2 = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11 * 12 * 13);
                            temp = temp2  / Math.Pow(numbX, 13);
                            break;
                        case 14:
                            UInt64 temp3 = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11 * 12 * 13 * 14);
                            temp = temp3 / Math.Pow(numbX, 14);
                            break;
                        case 15:
                            UInt64 temp4 = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11 * 12 * 13 * 14 * 15);
                            temp = temp4 / Math.Pow(numbX, 15);
                            break;
                        case 16:
                            UInt64 temp5 = (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10 * 11 * 12 * 13 * 14 * 15 * 16);
                            temp = temp5 / Math.Pow(numbX, 16);
                            break;
                        
                    }
                    Solution += temp;
                }
            }
            Console.WriteLine("{0,0:f5}", Solution);
        }
    }
}
