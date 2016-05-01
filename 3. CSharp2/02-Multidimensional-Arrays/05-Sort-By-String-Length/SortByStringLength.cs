using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _05_Sort_By_String_Length
{
    class SortByStringLength
    {
        public class myCompare : IComparer
        {
            int IComparer.Compare(object Right, object Left)
            {
                string strLeft = Left.ToString();
                string strRight = Right.ToString();

                if (strRight.Length < strLeft.Length)
                {
                    return -1;
                }
                else if (strRight.Length > strLeft.Length)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        static void Main()
        {
            // input
            // input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            string[] toSearch = new string[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = Console.ReadLine();
            }

            myCompare sortStrLength = new myCompare();

            Array.Sort(toSearch, sortStrLength);

            Console.WriteLine(string.Join(Environment.NewLine, toSearch));
        }
    }
}
