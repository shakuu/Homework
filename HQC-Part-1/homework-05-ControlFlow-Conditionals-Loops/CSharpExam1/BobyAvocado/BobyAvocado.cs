using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobyAvocado // 93/ 100 
{
    class BobyAvocado
    {
        static void Main()
        {

            //input
            uint BobbysHead = uint.Parse(Console.ReadLine());

            int NumbOfCombs = int.Parse(Console.ReadLine());

            //vars
            uint currBobby = 0;
            int OnesCounter = 0;
            int HighOnes = 0;
            uint BestComb = 0;

            uint currBobbyBit = 0;
            uint currCombBit = 0;

            int endPos = 0;

            bool canUse = true;

            // get comb Length
            for (int i = 0; i < 32; i++)
            {
                currBobby = (BobbysHead & (uint)(1 << 31 - i)) >> 31 - i;

                if (currBobby == 1)
                {
                    endPos = 31 - i;
                    break;
                }
            }



            for (int comb = 0; comb < NumbOfCombs; comb++)
            {
                // Read a New comb
                uint currComb = uint.Parse(Console.ReadLine());

                //reset
                OnesCounter = 0;
                canUse = true;

                // Compare to Bobbys Head
                for (int col = 0; col < 32; col++)
                {
                    // get bits 
                    currBobbyBit = (BobbysHead & (uint)(1 << col)) >> col;
                    currCombBit = (currComb & (uint)(1 << col)) >> col;

                    if (currBobbyBit == 1 &&
                        currCombBit == currBobbyBit)
                    {
                        canUse = false;
                    }

                    if (currCombBit == 1)
                    {
                        OnesCounter++;
                    }
                }

                // check if best
                if (canUse)
                {
                    if (OnesCounter > HighOnes)
                    {
                        BestComb = currComb;
                        HighOnes = OnesCounter;
                    }
                }

            }

            Console.WriteLine(BestComb);
        }
    }
}
