
namespace PointAndMatrix.Lists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GenericList<T> //where T : IComparer<T>
    {
        #region Fields
        private const int initialSize = 4;

        private T[] container;
        private int count;
        #endregion

        public GenericList()
        {
            this.container = new T[initialSize];
            this.count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count) throw new IndexOutOfRangeException("Element does not exist");
                return this.container[index];
            }
            set
            {
                if (index >= this.count) throw new IndexOutOfRangeException("Element does not exist");
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
                return count - 1;
            }
        }
        #endregion

        #region Methods

        public void Add(T element)
        {
            if (this.count + 1 > this.Capacity) ExpandCapacity();

            container[count] = element;
            count++;
        }
        public void Remove(int index)
        {
            count--;

            for (int i = index + 1; i <= count; i++)
                container[i - 1] = container[i];

        }
        public void Insert(int index, T element)
        {
            if (this.count + 1 > this.Capacity) ExpandCapacity();

            for (int i = count; i > index; i--)
            {
                container[i] = container[i - 1];
            }

            container[index] = element;
            count++;
        }
        public void Clear()
        {
            this.container = new T[initialSize];
        }
        
        public void Min<Type>()
        {
            
        }

        private void ExpandCapacity()
        {
            var newContainer = new T[this.Capacity * 2];

            for (int i = 0; i < container.Length; i++)
                newContainer[i] = container[i];

            this.container = newContainer;
        }
        


        #endregion
    }
}
