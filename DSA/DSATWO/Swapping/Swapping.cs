using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping
{
    class Swapping
    {
        static void Main(string[] args)
        {
            var numbersCount = int.Parse(Console.ReadLine());
            var pivotsList = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            var originalSet = new List<int>(numbersCount);
            //var originalStr = new StringBuilder();
            for (int i = 1; i <= numbersCount; i++)
            {
                originalSet.Add(i);
            }

            foreach (var pivot in pivotsList)
            {
                // possible size 1 


                //var parts = current.Split(new[] { pivot.ToString() }, StringSplitOptions.None);

                //if (current[0] == (char)pivot)
                //{
                //    current = string.Format("{0} {1}", parts[0].Trim(), pivot);
                //}
                //else if (current[strLen - 1] == (char)pivot)
                //{
                //    current = string.Format("{0} {1}", pivot, parts[0].Trim());
                //}
                //else
                //{
                //    current = string.Format("{0} {1} {2}", parts[1].Trim(), pivot, parts[0].Trim());

                var first = new List<int>();
                var second = new List<int>();
                var addLast = true;

                foreach (var el in originalSet)
                {
                    if (el == pivot)
                    {
                        addLast = false;
                        continue;
                    }

                    if (addLast)
                    {
                        second.Add(el);
                    }
                    else
                    {
                        first.Add(el);
                    }
                }

                originalSet = new List<int>();
                originalSet.AddRange(first);
                originalSet.Add(pivot);
                originalSet.AddRange(second);
            }

            Console.WriteLine(string.Join(" ", originalSet));
        }
    }
}

