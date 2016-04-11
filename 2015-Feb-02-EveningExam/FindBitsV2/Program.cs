using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBitsV2
{
    class Program
    {
        static void Main()
        {
            string toFind = Convert.ToString(int.Parse( Console.ReadLine()), 2).PadLeft(5, '0');
            int numbers = int.Parse(Console.ReadLine());

            List<int> toSearch = new List<int>();
            for ( int i = 0; i<numbers;i++)
            {
                toSearch.Add(int.Parse(Console.ReadLine()));
            }

            int counter = 0;
            for ( int i = 0; i< toSearch.Count;i++)
            {
                string currString = "00000";
                while(toSearch[i] > 0)
                {
                    currString = (toSearch[i] % 2).ToString() + currString;
                    currString = currString.Remove(currString.Length-1, 1);

                    if (currString==toFind)
                    {
                        counter++;
                    }

                    toSearch[i] >>= 1;
                }
            }

        }
    }
}
