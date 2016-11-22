using System;
using System.Collections.Generic;

namespace Problem12.Stack
{
    public class AutoResizeableStack<T>
    {
        private IList<T> elements;
        private int lastIndex;

        public AutoResizeableStack()
        {
            this.elements = new List<T>();
            this.lastIndex = 0;
        }

        public void Push(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            this.elements.Add(element);
            this.lastIndex++;
        }

        public T Pop()
        {
            var element = this.elements[this.lastIndex];
            this.lastIndex--;

            return element;
        }

        public T Peek()
        {
            if (this.lastIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }

            return this.elements[this.lastIndex];
        }
    }
}
