namespace OrderedBinarySearchTree.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// http://www.introprogramming.info/english-intro-csharp-book/read-online/chapter-17-trees-and-graphs/
    /// Source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderedBinarySearchTree<T>
    {
        public TreeNode<T> Root { get; set; }

        #region Add Node
        public void Add(T value)
        {
            this.Root = this.AddElement(value, this.Root, null);
        }

        private TreeNode<T> AddElement(T value, TreeNode<T> node, TreeNode<T> parent)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                node.Parent = parent;
            }
            else
            {
                var compare = node.CompareTo(value);

                if (compare > 0)
                {
                    node.LeftChild = AddElement(value, node.LeftChild, node);
                }
                else
                {
                    node.RightChild = AddElement(value, node.RightChild, node);
                }
            }

            return node;
        }
        #endregion
        
        public void Print()
        {
            PrintTreeDFS(this.Root);
            Console.WriteLine();
        }

        private void PrintTreeDFS(TreeNode<T> node)
        {
            if (node != null)
            {
                PrintTreeDFS(node.LeftChild);
                Console.Write(node.Value + " ");
                PrintTreeDFS(node.RightChild);
            }
        }
    }
}
