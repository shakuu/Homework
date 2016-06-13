namespace OrderedBinarySearchTree.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TreeNode<T> : IComparable<TreeNode<T>>, IComparable<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }

        public int CompareTo(TreeNode<T> other)
        {
            return Comparer<T>.Default.Compare(this.Value, other.Value);
        }

        public int CompareTo(T other)
        {
            return Comparer<T>.Default.Compare(this.Value, other);
        }
    }
}
