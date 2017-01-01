using System;
using System.Linq;

namespace FindNumber
{
    public class FindNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var stringsCount = int.Parse(input[0]);
            var targetString = int.Parse(input[1]);

            var myHeap = new BinaryHeap(targetString + 1);

            var strings = Console.ReadLine().Split(' ').ToArray();
            for (int stringIndex = 0; stringIndex < stringsCount; stringIndex++)
            {
                var nextString = strings[stringIndex];

                if (myHeap.Count > targetString)
                {
                    if (nextString.CompareTo(myHeap.Max) < 0)
                    {
                        myHeap.Replace(nextString);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    myHeap.Add(nextString);
                }
            }

            Console.WriteLine(myHeap.Max);
        }
    }

    public class BinaryHeap
    {
        private int targetSize;
        private int currentSize;

        private string[] heap;

        public BinaryHeap(int targetSize)
        {
            this.targetSize = targetSize;
            this.currentSize = 0;

            this.heap = new string[targetSize + 1].Select(x => string.Empty).ToArray();
        }

        public string Max
        {
            get
            {
                return this.heap[1];
            }
        }

        public int Count
        {
            get
            {
                return this.currentSize;
            }
        }

        public void Add(string element)
        {
            this.currentSize++;

            var currentIndex = this.currentSize;
            this.heap[currentIndex] = element;

            var parentIndex = this.GetParentIndex(currentIndex);
            while (parentIndex >= 1)
            {
                var parentNode = this.heap[parentIndex];
                if (this.heap[currentIndex].CompareTo(parentNode) > 0)
                {
                    this.heap = this.Swap(this.heap, currentIndex, parentIndex);
                    currentIndex = parentIndex;
                    parentIndex = this.GetParentIndex(parentIndex);
                }
                else
                {
                    break;
                }
            }
        }

        // SLOW/ Incorrect
        public void ReplaceWithPop(string element)
        {
            for (int i = 2; i <= this.currentSize; i++)
            {
                this.heap[i - 1] = this.heap[i];
            }

            this.heap[this.currentSize] = element;
            this.BubbleDown(1);
        }

        public void Replace(string element)
        {
            this.RemoveMax();
            this.Add(element);
        }

        public string RemoveMax()
        {
            var maxElement = this.heap[1];

            this.heap = this.Swap(this.heap, 1, this.currentSize);
            this.heap[this.currentSize] = "";
            this.BubbleDown(1);

            this.currentSize--;
            return maxElement;
        }

        private void BubbleDown(int index)
        {
            var sorted = false;
            while (!sorted)
            {
                var node = this.heap[index];

                var leftChildIndex = this.GetLeftChildIndex(index);
                var rightChildINdex = this.GetRightChildIndex(index);
                if (leftChildIndex < 0 && rightChildINdex < 0)
                {
                    break;
                }

                var leftNodeValue = "";
                if (leftChildIndex <= this.currentSize)
                {
                    leftNodeValue = this.heap[leftChildIndex];
                }

                var rightNodeValue = "";
                if (rightChildINdex <= this.currentSize)
                {
                    rightNodeValue = this.heap[rightChildINdex];
                }

                if (leftNodeValue.CompareTo(rightNodeValue) > 0)
                {
                    if (node.CompareTo(leftNodeValue) < 0)
                    {
                        this.heap = this.Swap(this.heap, index, leftChildIndex);
                        index = leftChildIndex;
                    }
                    else
                    {
                        sorted = true;
                    }
                }
                else
                {
                    if (node.CompareTo(rightNodeValue) < 0)
                    {
                        this.heap = this.Swap(this.heap, index, rightChildINdex);
                        index = rightChildINdex;
                    }
                    else
                    {
                        sorted = true;
                    }
                }
            }
        }

        private int GetLeftChildIndex(int index)
        {
            var childIndex = index * 2;
            return childIndex;
        }

        private int GetRightChildIndex(int index)
        {
            var childIndex = index * 2 + 1;
            return childIndex;
        }

        private int GetParentIndex(int index)
        {
            var parentIndex = index / 2;
            return parentIndex;
        }

        private string[] Swap(string[] heap, int indexA, int indexB)
        {
            var temp = heap[indexA];
            this.heap[indexA] = heap[indexB];
            this.heap[indexB] = temp;

            return heap;
        }
    }
}
