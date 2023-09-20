using System;
using System.Collections.Generic;

namespace BinarySearchTreeWithoutRecursion
{
    public class Program
    {
        public static List<int> Part1()
        {

            ///Instantiate random number generator
            Random random = new Random();

            ///Make a list to hold the values generated from the random number generator
            List<int> randomList = new List<int>();

            ///define min/max range of numbers
            ///For loop to iterate through and generate 1000 integers
            for (int i = 0; i < 1000; i++)
            {
                int number = random.Next(1, 99);
                randomList.Add(number);
            }
            ///List.sort
            return randomList;

        }

        //This is not a BALANCED tree, simply a BST.
        public static void Main(string[] args)
        {
            BSTTree tree = new BSTTree();
            List<int> sortedList = Part1();

            foreach (var v in sortedList)
            {
                tree.BuildTheTree(v);
            }
        }
    }
}