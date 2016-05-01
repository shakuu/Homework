using System;


namespace _04_Binary_Search
{
    class BinarySearch
    {
        static void Main()
        {
            // get K
            int toFindK = int.Parse(Console.ReadLine());

            // input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            int[] toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(toSearch);

            int SearchResult = Array.BinarySearch(toSearch, toFindK);
            // -1 -> ToFindK is smallest,  
            // less than -1 -> next largest element in the array
            // Negative number complement ( ~ ) of index
            // positive -> the index of the element found.


            if (SearchResult == -1)
            {
                Console.WriteLine("No result!\n" + Environment.NewLine +
                        "{0} is the smallest element", toFindK);
            }
            else if (SearchResult < -1)
            {
                Console.WriteLine("Largest element < {0}:" + Environment.NewLine +
                        "value: {1}, position: [{2}]",
                         toFindK, toSearch[(~SearchResult) - 1], (~SearchResult) - 1);
            }
            else
            {
                Console.WriteLine("Exact Match:" + Environment.NewLine +
                        "value: {0}, position: [{1}]", toFindK, SearchResult);
            }
        }
    }
}
