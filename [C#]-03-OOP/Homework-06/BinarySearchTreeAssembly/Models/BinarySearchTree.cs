namespace BinarySearchTreeAssembly.Models
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T>
    {
        private List<TreeNode<T>> children;
        private TreeNode<T> root;
        
        public BinarySearchTree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public BinarySearchTree(TreeNode<T> root, params TreeNode<T>[] children)
            : this(root)
        {
            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }
        
        
        public List<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
            set
            {
                this.root = value;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child.HasParent)
            {
                throw new ArgumentException
                    ("This TreeNode<T> already has a parent");
            }

            if (this.Children.Count == 2)
            {
                throw new ArgumentException
                    ("Each node in a Binary Tree can have 2 children nodes at most");
            }

            this.Children.Add(child);
            child.HasParent = true;
        }

        /// <summary>
        /// Remove a child of this specific tree
        /// TODO: Remove out of all
        /// </summary>
        /// <param name="child"></param>
        public void RemoveChild(TreeNode<T> child)
        {
            var index = this.Children.IndexOf(child);
            if (index < 0)
            {
                throw new ArgumentException("Element not found");
            }

            child.HasParent = false;
            this.Children.RemoveAt(index);
        }
    }
}
