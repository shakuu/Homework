﻿namespace StartUp._04_BinaryTree_Tests
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

            var tree1 = new OrderedBinarySearchTree<string>();
            tree1.Add("5");
            tree1.Add("4");
            tree1.Add("6");
            tree1.Add("2");
            tree1.Add("100");

            var tree2 = new OrderedBinarySearchTree<string>();
            tree2.Add("5");
            tree2.Add("4");
            tree2.Add("6");
            tree2.Add("2");
            tree2.Add("100");

            Console.WriteLine(tree.ToString());

            Console.WriteLine(tree.GetHashCode());
            Console.WriteLine(tree2.GetHashCode());
            Console.WriteLine(tree1.GetHashCode());
        }
    }
}
