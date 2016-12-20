using System;

using Wintellect.PowerCollections;

public class PriorityQueue<T> where T : IComparable<T>
{
    private OrderedBag<T> queue;

    public int Count
    {
        get
        {
            return queue.Count;
        }
    }

    public PriorityQueue()
    {
        queue = new OrderedBag<T>();
    }

    public void Enqueue(T element)
    {
        queue.Add(element);
    }

    public T Dequeue()
    {
        T element = queue.RemoveFirst();
        return element;
    }
}
