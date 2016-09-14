using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]);
        SelectionSort(new int[1]);

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] toSort)
        where T : IComparable<T>
    {
        Debug.Assert(toSort != null, "Array to be sorted cannot be null");

        for (int index = 0; index < toSort.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(toSort, index, toSort.Length - 1);
            Swap(ref toSort[index], ref toSort[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] collectionToSearch, T value)
        where T : IComparable<T>
    {
        Debug.Assert(collectionToSearch != null, "Array parameter is null.");
        Debug.Assert(value != null, "value is null.");

        var index = BinarySearch(collectionToSearch, value, 0, collectionToSearch.Length - 1);

        Debug.Assert(index < collectionToSearch.Length, "index is larget than array size.");

        return index;
    }

    private static int FindMinElementIndex<T>(T[] elements, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(elements != null, "The passed array parameter is null.");
        Debug.Assert(startIndex <= endIndex, "startIndex is larger than endIndex.");
        Debug.Assert(endIndex == elements.Length - 1, "endIndex is not the last element of the array.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (elements[i].CompareTo(elements[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(0 <= minElementIndex, "minElementIndex is less than zero.");
        Debug.Assert(minElementIndex <= endIndex, "minElementIndex is larger than array size.");

        return minElementIndex;
    }

    private static void Swap<T>(ref T itemA, ref T itemB)
    {
        Debug.Assert(itemA != null, "itemA is null.");
        Debug.Assert(itemB != null, "itemB is null.");

        T oldX = itemA;
        itemA = itemB;
        itemB = oldX;
    }

    private static int BinarySearch<T>(T[] collectionToSearch, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            Debug.Assert(startIndex >= 0, "startIndex is less than zero.");
            Debug.Assert(endIndex < collectionToSearch.Length, "endInde ix larger than array size.");

            int midIndex = (startIndex + endIndex) / 2;
            if (collectionToSearch[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (collectionToSearch[midIndex].CompareTo(value) < 0)
            {
                startIndex = midIndex + 1;
            }
            else
            {
                endIndex = midIndex - 1;
            }
        }

        return -1;
    }
}