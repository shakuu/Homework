
namespace PointAndMatrix.Lists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Attributes;

    [Version(0, 11)]
    public class GenericList<T> : IEnumerable
    {
        #region Fields
        private const int initialSize = 4;

        private T[] container;
        private int count;
        #endregion

        public GenericList()
        {
            this.container = new T[initialSize];
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0) throw new IndexOutOfRangeException("Element does not exist");
                return this.container[index];
            }
            set
            {
                if (index >= this.count || index < 0) throw new IndexOutOfRangeException("Element does not exist");
                this.container[index] = value;
            }
        }

        #region Properties
        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Count must be a positive number");
                }
                this.count = value;
            }
        }
        public int Capacity
        {
            get
            {
                return this.container.Length;
            }
        }
        public T Last
        {
            get
            {
                if (count == 0)
                {
                    throw new ArgumentOutOfRangeException("List is empty");
                }
                return this.container[count - 1];
            }
        }
        public int LastIndex
        {
            get
            {
                return this.Count - 1;
            }
        }
        #endregion

        #region Methods

        public void Add(T element)
        {
            if (this.count + 1 > this.Capacity) ExpandCapacity();

            this.container[count] = element;
            this.Count++;
        }
        public void Remove(int index)
        {
            if (index < 0 || count <= index)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            this.Count--;

            for (int i = index + 1; i <= this.Count; i++)
                this.container[i - 1] = this.container[i];

        }
        public void Insert(int index, T element)
        {
            if (index < 0 || count < index)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            if (this.count + 1 > this.Capacity) ExpandCapacity();

            for (int i = count; i > index; i--)
            {
                container[i] = container[i - 1];
            }

            this.container[index] = element;
            this.Count++;
        }
        public void Clear()
        {
            this.container = new T[initialSize];
            this.Count = 0;
        }

        //Original: 
        // Enumerator out of private array
        public IEnumerator GetEnumerator()
        {
            // 
            var newEnumerator = this.container
                .Take(this.Count).GetEnumerator();

            return newEnumerator;
        }

        //// YIELD RETURN
        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        yield return this[i];
        //    }
        //}

        #region Comparing
        public T Min()
        {
            var min = this.container[0];

            for (int i = 0; i < count; i++)
            {
                try
                {
                    var compare = Comparer<T>.Default.Compare(min, this.container[i]);

                    if (compare == 1)
                    {
                        min = this.container[i];
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Type does not implement IComparable");
                    throw;
                }
                
            }

            return min;
        }

        public T Max()
        {
            var max = this.container[0];

            for (int i = 0; i < count; i++)
            {
                try
                {
                    var compare = Comparer<T>.Default.Compare(max, this.container[i]);

                    if (compare == -1)
                    {
                        max = this.container[i];
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Type does not implement IComparable");
                    throw;
                }
            }

            return max;
        }
        #endregion
        
        private void ExpandCapacity()
        {
            var newContainer = new T[this.Capacity * 2];

            for (int i = 0; i < this.container.Length; i++)
                newContainer[i] = this.container[i];

            this.container = newContainer;
        }
        
        #endregion
    }
}
