using System;

namespace _04_Sub_String_In_Text_2
{
    class SubstringinText2
    {
        static void Main()
        {
            var toFind = Console.ReadLine().ToLower();

            var toSearch = Console.ReadLine().ToLower();

            var curIndex = toSearch.IndexOf(toFind);

            var counter = 0;

            while (curIndex >= 0)
            {
                counter++;

                curIndex = toSearch.IndexOf(toFind, ++curIndex);
            }

            Console.WriteLine(counter);
        }
    }
}
