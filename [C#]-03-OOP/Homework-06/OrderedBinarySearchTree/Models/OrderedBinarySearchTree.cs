namespace OrderedBinarySearchTreeAssembly.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    /// <summary>
    /// http://www.introprogramming.info/english-intro-csharp-book/read-online/chapter-17-trees-and-graphs/
    /// Source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public struct BinarySearchTree<T> 
        : IEnumerable<TreeNode<T>>, ICloneable, IComparable 
        where T : IComparable
    {
        private const int MultiplyHash = 337;

        private List<TreeNode<T>> nodes;

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

        #region Find Node
        public TreeNode<T> FindNode(T value)
        {
            var node = this.Root;

            while (node != null)                      // If next node is null, then 
            {                                         // search has NOT been successful.
                var compare = node.CompareTo(value);  // Compare node value to search value
                                                      //
                if (compare > 0)                      // If Node value is larger (compare == 1)
                {                                     // next node to check is left child of 
                    node = node.LeftChild;            // current node.
                }                                     //
                else if (compare < 0)                 // If Node value is smaller
                {                                     // check it's right child.
                    node = node.RightChild;           //
                }                                     //
                else                                  // If the two values are equal,
                {                                     // search has been successful.
                    break;                            //
                }                                     //
            }

            return node;
        }

        public bool Contains(T value)
        {
            var contains = this.FindNode(value) != null;
            return contains;
        }
        #endregion

        #region Remove Node
        public void RemoveValue(T value)
        {
            var node = this.FindNode(value);        // Search for a node with required value .

            if (node != null)                       // If such a node exists, 
            {                                       // then remove it.
                // Remove                           // 
            }                                       // 
        }

        public void RemoveNode(TreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                // Find the smallest value on the right sub tree
                var replacement = node.RightChild;

                while (replacement.LeftChild != null)      // Traverse the tree down,
                {                                          // while there are elements 
                    replacement = replacement.LeftChild;   // to the left of the current 
                }                                          // node ( smaller elements ).

                node.Value = replacement.Value;     // node to remove value = smallest value
                node = replacement;                 // node to remove -> the node with the smallest value
            }

            // Check for children.
            var child = node.LeftChild == null ?
                        node.RightChild : node.LeftChild;

            if (child != null)  // one child
            {
                if (node.Parent == null)                        // If the node to remove has no parent
                {                                               // then it is the root.
                    this.Root = null;                           // Remove the root.
                }                                               //
                else                                            //
                {                                               //
                    if (node.Parent.LeftChild == node)          // If node to remove is the left child 
                    {                                           // of it s parent, the left of the parent
                        node.Parent.LeftChild = child;          // becomes the only child of the node to
                    }                                           // be removed
                    else                                        //
                    {                                           //
                        node.Parent.RightChild = child;         // Otherwise replace the right child 
                    }
                }
            }
            else                // no children
            {
                if (node.Parent == null)                        // If the node to remove has no parent
                {                                               // then it is the root.
                    this.Root = null;                           // Remove the root.
                }                                               //
                else                                            //
                {                                               //
                    if (node.Parent.LeftChild == node)          // If node to remove is the left child 
                    {                                           // of it s parent, then remove left child
                        node.Parent.LeftChild = null;           //
                    }                                           //
                    else                                        //
                    {                                           //
                        node.Parent.RightChild = null;          // Otherwise remove the right child.
                    }
                }
            }
        }
        #endregion

        #region Overrides
        public static bool operator ==(BinarySearchTree<T> one, BinarySearchTree<T> other)
        {
            return one.Equals(other);
        }

        public static bool operator !=(BinarySearchTree<T> one, BinarySearchTree<T> other)
        {
            return !one.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(BinarySearchTree<T>))
            {
                throw new Exception("Invalid object type");
            }

            var other = (BinarySearchTree<T>)obj;

            var hashThis = this.GetHashCode();
            var hashOther = other.GetHashCode();

            return hashThis == hashOther;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var node in this)
            {
                output.Append(node.Value);
                output.Append(" ");
            }

            return output.ToString().Trim();
        }

        public override int GetHashCode()
        {
            var hash = 37;

            unchecked
            {
                foreach (var node in this)
                {
                    hash = MultiplyHash * hash + node.GetHashCode();
                }
            }

            return hash;
        }

        #endregion

        #region Interfaces
        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            this.nodes = new List<TreeNode<T>>();

            this.GetAllElements(this.Root);

            foreach (var node in nodes)
            {
                yield return node;
            }
        }

        private void GetAllElements(TreeNode<T> node)
        {
            if (node != null)
            {
                GetAllElements(node.LeftChild);
                this.nodes.Add(node);
                GetAllElements(node.RightChild);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            object clone;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);

                stream.Position = 0;

                clone = formatter.Deserialize(stream);
            }

            return clone;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
