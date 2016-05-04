using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Remove_Element_Again
{
    class Program
    {
        static void Main()
        {
            // input 
            int arraySize = int.Parse(Console.ReadLine());

            List<int> toSearch = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                toSearch.Add(int.Parse(Console.ReadLine()));
            }

            // variables
            var Conflicts = new int[arraySize];

            int Removed = 0;

            while (true)
            {
                // Pass 1 - Left To Rigth
                Conflicts = new int[toSearch.Count()];

                for (int curElement = 0; curElement < toSearch.Count(); curElement++)
                {
                    // check each element after
                    for (int nextElement = curElement + 1; nextElement < toSearch.Count(); nextElement++)
                    {
                        if (toSearch[curElement] > toSearch[nextElement])
                        {
                            Conflicts[nextElement]++;
                        }
                    }
                }

                if (Conflicts.Sum() > 0)
                {
                    // remove that element
                    toSearch.RemoveAt(Array.IndexOf(Conflicts, Conflicts.Max()));
                    Removed++;
                }
                else
                {
                    break;
                }

                // Pass 2 - Rigth To Left
                Conflicts = new int[toSearch.Count()];

                for (int curElement = toSearch.Count() - 1; curElement > 0; curElement--)
                {
                    // check each element after
                    for (int nextElement = curElement - 1; nextElement >= 0; nextElement--)
                    {
                        if (toSearch[curElement] < toSearch[nextElement])
                        {
                            Conflicts[nextElement]++;
                        }
                    }
                }

                if (Conflicts.Sum() > 0)
                {
                    // remove that element
                    toSearch.RemoveAt(Array.IndexOf(Conflicts, Conflicts.Max()));
                    Removed++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(Removed);
        }
    }
}
