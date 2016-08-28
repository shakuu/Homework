using System;

namespace Feathers
{
    class Feathers
    {
        static void Main()
        {
            //input 
            // birds 0 - 80 000, feathers 0 2 000 000 000
            int numBirds = int.Parse(Console.ReadLine());
            int numFeathers = int.Parse(Console.ReadLine());

            // get average
            double AvgFeathers = (double)numFeathers / (double)numBirds;

            // modify
            // even * 123 123 123 123
            double evenResult = 0;

            if (numBirds%2 == 0)
            {
                evenResult =AvgFeathers * 123123123123;
            }
            else if (numBirds%2!=0)
            {
                evenResult = AvgFeathers / 317;
            }

            //output
            Console.WriteLine(evenResult.ToString("0.0000"));
        }
    }
}
