
namespace BinarySearchTreeAssembly.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;

        public TreeNode(T value)
        {
            this.Value = value;
            hasParent = false;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
            set
            {
                this.hasParent = value;
            }
        }
    }
}
