using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBitsV2
{
    class FindBitsV2
    {
        static void Main()
        {
            string toFind = Convert.ToString(int.Parse( Console.ReadLine()), 2).PadLeft(5, '0');
            int numbers = int.Parse(Console.ReadLine());

            List<long> toSearch = new List<long>();
            for ( int i = 0; i<numbers;i++)
            {
                toSearch.Add(long.Parse(Console.ReadLine()));
            }

            while(toFind.Length>5)
            {
                toFind = toFind.Remove(0, 1);
            }

            int bits = 1;
            int counter = 0;
            string currString = "";
            for ( int i = 0; i< toSearch.Count;i++)
            {
                bits = 0;
                currString = "";
                while( bits < 29)
                {
                    currString = (toSearch[i] % 2).ToString() + currString;
                    if (currString.Length > 5)
                    {
                        currString = currString.Remove(currString.Length - 1, 1);
                    }
                    if (currString==toFind)
                    {
                        counter++;
                    }

                    toSearch[i] >>= 1;
                    bits++;
                }
              
               
            }

            Console.WriteLine(counter);
        }
    }
}
