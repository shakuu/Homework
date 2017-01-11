using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwappingNodesArray
{
    public class LinkedNodeArray
    {
        private IList<LinkedNode> nodes;
        private LinkedNode firstNode;
        private LinkedNode lastNode;

        public LinkedNodeArray(int size)
        {
            this.nodes = this.CreateArray(size);
            this.firstNode = nodes[0];
            this.lastNode = nodes[size - 1];
        }

        public void Pivot(int pivot)
        {
            var pivotIndex = pivot - 1;
            var pivotNode = this.nodes[pivotIndex];

            if (pivotNode.Previous == null)
            {
                this.HandlePivotFirstNode(pivotNode);
            }
            else if (pivotNode.Next == null)
            {
                this.HandlePivotLastNode(pivotNode);
            }
            else
            {
                this.HandlePivot(pivotNode);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            var nextNodeToPrint = this.firstNode;
            while (nextNodeToPrint != null)
            {
                result.Append(nextNodeToPrint.Value);
                result.Append(" ");

                nextNodeToPrint = nextNodeToPrint.Next;
            }

            result.Length--;
            return result.ToString();
        }

        private void HandlePivot(LinkedNode pivotNode)
        {
            var nextNode = this.firstNode;
            var previousNode = this.lastNode;

            this.lastNode = pivotNode.Previous;
            this.lastNode.Next = null;

            this.firstNode = pivotNode.Next;
            this.firstNode.Previous = null;

            pivotNode.Next = nextNode;
            nextNode.Previous = pivotNode;

            pivotNode.Previous = previousNode;
            previousNode.Next = pivotNode;
        }

        private void HandlePivotFirstNode(LinkedNode pivotNode)
        {
            pivotNode.Previous = this.lastNode;
            this.lastNode.Next = pivotNode;
            this.lastNode = pivotNode;

            this.firstNode = pivotNode.Next;
            pivotNode.Next = null;
            this.firstNode.Previous = null;
        }

        private void HandlePivotLastNode(LinkedNode pivotNode)
        {
            pivotNode.Next = this.firstNode;
            this.firstNode.Previous = pivotNode;
            this.firstNode = pivotNode;

            this.lastNode = pivotNode.Previous;
            pivotNode.Previous = null;
            this.lastNode.Next = null;
        }

        private IList<LinkedNode> CreateArray(int size)
        {
            var nodesArray = new LinkedNode[size];
            nodesArray[0] = new LinkedNode(1);
            for (int i = 1; i < size; i++)
            {
                var previousNode = nodesArray[i - 1];
                var newNode = new LinkedNode(i + 1);
                newNode.Previous = previousNode;
                previousNode.Next = newNode;
                nodesArray[i] = newNode;
            }

            return nodesArray;
        }
    }

    public class LinkedNode
    {
        public LinkedNode(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public LinkedNode Next { get; set; }

        public LinkedNode Previous { get; set; }
    }

    public class SwappingNodes
    {
        public static void Main()
        {
            var numbersCount = int.Parse(Console.ReadLine());
            var pivotsList = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var nodesArray = new LinkedNodeArray(numbersCount);

            foreach (var pivot in pivotsList)
            {
                nodesArray.Pivot(pivot);
            }

            Console.WriteLine(nodesArray.ToString());
        }
    }
}