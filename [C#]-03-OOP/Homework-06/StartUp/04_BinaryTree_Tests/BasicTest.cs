namespace StartUp._04_BinaryTree_Tests
{
    using OrderedBinarySearchTree.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class BasicTest
    {
        public static void Test_01()
        {
            var tree = new OrderedBinarySearchTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);
            tree.Add(2);
            tree.Add(100);

            tree.Print();
        }
    }
}
