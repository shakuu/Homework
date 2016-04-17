using System;

namespace SheetsWithBits
{
    class SheetsWithBits
    {
        static void Main()
        {
            int AsyaNeeds = int.Parse(Console.ReadLine());

            for (int i = 10; i >= 0; i--)
            {
                if(AsyaNeeds%2==0)
                {
                    Console.WriteLine("A" + i.ToString());
                }
                AsyaNeeds = AsyaNeeds >> 1;
            }

        }
    }
}
