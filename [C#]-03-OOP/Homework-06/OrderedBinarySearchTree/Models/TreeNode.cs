namespace OrderedBinarySearchTreeAssembly.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class TreeNode<T> : IComparable<TreeNode<T>>, IComparable<T>, IComparable
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

        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(TreeNode<T>))
            {
                throw new Exception("Invalid argument type");
            }

            var check = obj as TreeNode<T>;

            return this.CompareTo(check);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(TreeNode<T>))
            {
                throw new Exception("Invalid object type");
            }

            var compare = this.CompareTo(obj as TreeNode<T>);

            if (compare == 0) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            var hash = 37;
            var multiply = 337;
            unchecked
            {
                hash = hash * multiply + this.Value.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        //public static bool operator ==(TreeNode<T> one, TreeNode<T> other)
        //{
        //    try
        //    {
        //        return (one.GetHashCode() == other.GetHashCode());
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool operator !=(TreeNode<T> one, TreeNode<T> other)
        //{
        //    return !(one == other);
        //}
    }
}
