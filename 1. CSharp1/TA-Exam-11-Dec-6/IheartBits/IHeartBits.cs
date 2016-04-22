using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IheartBits
{
    class IHeartBits
    {
        static void Main()
        {
            //input -> amount of numbers to process
            int numInput = int.Parse(Console.ReadLine());

            // arrays to store numbers and rresults
            uint[] inputP = new uint[numInput];
            uint[] notP = new uint[numInput]; //P̃
            uint[] invertP = new uint[numInput]; //P̈
            uint[] result = new uint[numInput];

            // for every number
            for (int index = 0; index < numInput; index++)
            {
                // get a new number
                inputP[index] = uint.Parse(Console.ReadLine());

                // Step 1: reverse ONLY bits within the number
                //notP[index] = (~inputP[index]); inverts 32 bits 
                uint tempMask = 1;
                uint tempNumb = inputP[index];

                // working 
                while (tempNumb > 0)
                {
                    if ((tempNumb & tempMask) == 1) // if 1 add 0
                    {
                        notP[index] = notP[index] << 1;
                    }
                    else                                            // if 0 add 1
                    {
                        notP[index] = notP[index] << 1;
                        notP[index] = notP[index] | tempMask;
                    }
                    //1 bit right and go again
                    tempNumb = tempNumb >> 1;
                }

                // Step 2; get reveres bit sequence
                //read bits -> +1 to add 1, << to add 0
                tempMask = 1;
                tempNumb = inputP[index];

                while (tempNumb > 0)
                {
                    if ((tempNumb & tempMask) == 1) // if 1 add 1
                    {
                        invertP[index] = invertP[index] << 1;
                        invertP[index] = invertP[index] | tempMask;
                    }
                    else
                    {
                        invertP[index] = invertP[index] << 1; // if 0 add 0
                    }
                    //1 bit right and go again
                    tempNumb = tempNumb >> 1;
                }

                // get result
                result[index] = (inputP[index] ^ notP[index]);
                result[index] = result[index] & invertP[index];

                //print
                Console.WriteLine(invertP[index]);
            }
        }
    }
}
