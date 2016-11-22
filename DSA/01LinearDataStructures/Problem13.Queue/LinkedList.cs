using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem13.Queue
{
    public class LinkedList<T> : IEnumerable<ListItem<T>>
    {
        public ListItem<T> FirstElement { get; set; }

        public void Add(ListItem<T> element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (this.FirstElement == null)
            {
                this.FirstElement = element;
            }
            else
            {
                var lastElement = this.GetLastElement();
                lastElement.NextItem = element;
            }
        }

        public IEnumerator<ListItem<T>> GetEnumerator()
        {
            var nextElement = this.FirstElement;
            do
            {
                yield return nextElement;
                nextElement = nextElement.NextItem;
            }
            while (nextElement.NextItem != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private ListItem<T> GetLastElement()
        {
            var lastElement = this.FirstElement;
            while (lastElement.NextItem != null)
            {
                lastElement = lastElement.NextItem;
            }

            return lastElement;
        }
    }
}
