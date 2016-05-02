using System;

namespace GPS2
{
    class GPS2
    {
        static void Main()
        {
            // get number
            string number = Console.ReadLine();

            long sumeven = 0;
            long sumodd = 0;

            //even sum
            for (int even = 0; even < number.Length; even += 2)
            {
                sumeven += number[even] - '0';
            }
            // odd sum
            for (int odd = 1; odd < number.Length; odd += 2)
            {
                sumodd += number[odd] - '0';
            }

            //prnting
            if (sumeven > sumodd)
            {
                Console.WriteLine("right" + " " + sumeven);
            }

            if (sumodd > sumeven)
            {
                Console.WriteLine("left" + " " + sumodd);
            }

            if (sumodd == sumeven)
            {
                Console.WriteLine("straight" + " " + sumeven);
            }
        }
    }
}
