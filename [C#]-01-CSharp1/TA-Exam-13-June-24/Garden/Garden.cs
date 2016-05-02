using System;
using System.Collections.Generic;

namespace Garden
{
    class Garden
    {
        static void Main()
        {
            //    Dictionary<string, double> SeedPrices = new Dictionary<string, double>()
            //    {
            //        {"tomato", 0.5 },
            //        {"cucumber", 0.4 },
            //        {"potato" , 0.25},
            //        {"carrot", 0.6 },
            //        { "cabbage", 0.3 },
            //        {"beans", 0.4 }
            //    };

            //input by definition
            const int GarderArea = 250;
            double[] Prices = new double[6] { 0.5, 0.4, 0.25, 0.6, 0.3, 0.4 };
            //SIMPLE 
            int areaUsed = 0;
            double Cost = 0;
            for (int i = 0; i < 5; i++)
            {
                //seeds cost
                Cost += int.Parse(Console.ReadLine()) * Prices[i];
                //get area
                areaUsed += int.Parse(Console.ReadLine());
            }
            //add Potato Cost
            Cost += int.Parse(Console.ReadLine()) * Prices[5];

            //output
            Console.WriteLine("Total costs: {0:F2}", Cost);
            if (GarderArea > areaUsed)
            {
                Console.WriteLine("Beans area: {0}", GarderArea - areaUsed);
            }
            else if (GarderArea == areaUsed)
            {
                Console.WriteLine("No area for beans");
            }
            else
            {
                Console.WriteLine("Insufficient area");
            }

        }
    }
}
