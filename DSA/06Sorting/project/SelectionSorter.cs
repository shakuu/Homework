using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var collectionCount = collection.Count;
            for (int i = 0; i < collectionCount - 1; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < collectionCount; j++)
                {
                    var compare = collection[j].CompareTo(collection[minIndex]);
                    if (compare < 0)
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    var swappedValue = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = swappedValue;
                }
            }
        }
    }
}
