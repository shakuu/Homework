namespace StartUp._04_BinaryTree_Tests
{
    using OrderedBinarySearchTreeAssembly.Models;
    using System;

    public static class BasicTest
    {
        public static void Test_01()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);
            tree.Add(2);
            tree.Add(100);

            var tree1 = new BinarySearchTree<string>();
            tree1.Add("5");
            tree1.Add("4");
            tree1.Add("6");
            tree1.Add("2");
            tree1.Add("100");

            var tree2 = new BinarySearchTree<string>();
            tree2.Add("5");
            tree2.Add("4");
            tree2.Add("6");
            tree2.Add("2");
            tree2.Add("100");

            var type = tree2.GetType();
            var tree3 = (BinarySearchTree<string>)tree2.Clone();

            Console.WriteLine(tree.ToString());

            Console.WriteLine(tree.GetHashCode());
            Console.WriteLine(tree2.GetHashCode());
            Console.WriteLine(tree1.GetHashCode());
            Console.WriteLine(tree3.GetHashCode());
        }
    }
}
