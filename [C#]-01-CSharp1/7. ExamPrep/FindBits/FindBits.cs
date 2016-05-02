using System;


namespace FindBits
{
    class FindBits
    {
        static void Main()
        {
            long toFind = long.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            long[] toParse = new long[number];
            for(int i = 0;i< number; i++)
            {
                toParse[i] = long.Parse(Console.ReadLine());
            }

           
              int  leadingZero = 1;
                leadingZero <<= 4;

            long resultZero;
            int counter = 0;
            for ( int p = 0; p< number;p++)
            {
                for ( int i = 0; i < 30; i++)
                {
                    long result = toParse[p] & toFind;
                    if ((toFind & leadingZero) ==1)
                    {
                        resultZero = toParse[p] & leadingZero;
                    }
                    else 
                    {
                        resultZero = toParse[p] ^ leadingZero;
                    }
                    if ( result== toFind && (resultZero>>4) ==1 )
                    {
                        counter++;
                    }
                    toParse[p] = toParse[p] >> 1;
                }
            }
            Console.WriteLine(counter);

        }
    }
}
