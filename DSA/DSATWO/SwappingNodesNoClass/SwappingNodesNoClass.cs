using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwappingNodesArray
{
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

            var nodesArray = new LinkedNode[numbersCount];
            nodesArray[0] = new LinkedNode(1);
            for (int i = 1; i < numbersCount; i++)
            {
                var previousNode = nodesArray[i - 1];
                var newNode = new LinkedNode(i + 1);
                newNode.Previous = previousNode;
                previousNode.Next = newNode;
                nodesArray[i] = newNode;
            }

            var firstNode = nodesArray[0];
            var lastNode = nodesArray[numbersCount - 1];
            foreach (var pivot in pivotsList)
            {
                var pivotIndex = pivot - 1;
                var pivotNode = nodesArray[pivotIndex];

                // In case pivotNode is firstNode
                if (pivotNode.Previous == null)
                {
                    pivotNode.Previous = lastNode;
                    lastNode.Next = pivotNode;
                    lastNode = pivotNode;

                    firstNode = pivotNode.Next;
                    pivotNode.Next = null;
                    firstNode.Previous = null;

                    continue;
                }

                // In case pivotNote is lastNode
                if (pivotNode.Next == null)
                {
                    pivotNode.Next = firstNode;
                    firstNode.Previous = pivotNode;
                    firstNode = pivotNode;

                    lastNode = pivotNode.Previous;
                    pivotNode.Previous = null;
                    lastNode.Next = null;

                    continue;
                }

                var nextNode = firstNode;
                var previousNode = lastNode;

                lastNode = pivotNode.Previous;
                lastNode.Next = null;

                firstNode = pivotNode.Next;
                firstNode.Previous = null;

                pivotNode.Next = nextNode;
                nextNode.Previous = pivotNode;

                pivotNode.Previous = previousNode;
                previousNode.Next = pivotNode;
            }

            var result = new StringBuilder();
            var nextNodeToPrint = firstNode;
            while (nextNodeToPrint != null)
            {
                result.Append(nextNodeToPrint.Value);
                result.Append(" ");

                nextNodeToPrint = nextNodeToPrint.Next;
            }

            result.Length--;
            Console.WriteLine(result.ToString());
        }
    }
}