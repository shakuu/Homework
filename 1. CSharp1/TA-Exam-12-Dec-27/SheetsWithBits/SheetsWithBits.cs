using System;

namespace SheetsWithBits
{
    class SheetsWithBits
    {
        static void Main()
        {
            int AsyaNeeds = int.Parse(Console.ReadLine());

            int checkMask = 1;

            for (int i = 10; i >= 0; i--)
            {
                if((AsyaNeeds&checkMask) ==1)
                {
                    Console.WriteLine("A" + i.ToString());
                }
                AsyaNeeds = AsyaNeeds >> 1;
            }

        }
    }
}
