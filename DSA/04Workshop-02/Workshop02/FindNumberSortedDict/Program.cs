using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberSortedDict
{
    public class FindNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var stringsCount = int.Parse(input[0]);
            var targetString = int.Parse(input[1]);

            var myHeap = new SortedSet<string>();

            var strings = Console.ReadLine().Split(' ').ToArray();
            for (int stringIndex = 0; stringIndex < stringsCount; stringIndex++)
            {
                var nextString = strings[stringIndex];

                if (myHeap.Count > targetString)
                {
                    if (nextString.CompareTo(myHeap.Max) < 0)
                    {
                        if (myHeap.Contains(nextString))
                        {
                            targetString--;
                        }

                        myHeap.Remove(myHeap.Max);
                        myHeap.Add(nextString);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    myHeap.Add(nextString);
                }
            }

            Console.WriteLine(myHeap.Max);
        }
    }
}
