namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.items)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            var left = 0;
            var right = this.items.Count;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (this.items[mid].CompareTo(item) < 0)
                {
                    left = mid + 1;
                }
                else if (this.items[mid].CompareTo(item) > 0)
                {
                    right = mid - 1;
                }
                else if (this.items[mid].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
