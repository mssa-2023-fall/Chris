using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

internal class Program {
    private static void Main(string[] args) {
        var list1 = Part1();
        Part2();
        
    }

    private static List<int> Part1() {

        ///Instantiate random number generator
        Random random = new Random();

        ///Make a list to hold the values generated from the random number generator
        List<int> randomList = new List<int>();

        ///define min/max range of numbers
        ///For loop to iterate through and generate 1000 integers
        for (int i = 0; i < 1000; i++) {
            int number = random.Next(1, 99);
            randomList.Add(number);
        }
        ///List.sort
        randomList.Sort();
        randomList.Reverse();

        return randomList;

    }

    private static void Part2() {
        //throw new NotImplementedException();


        Random random = new Random();
        //binary tree must be built on a sorted list
        BinaryTree tree = new BinaryTree();

        //build an array of 1000 random ints
        int[] insertToTreeArr = new int[1000];
        for (int i = 0; i < insertToTreeArr.Length; i++)
        {
            insertToTreeArr[i] = random.Next();
            //sort array using built in Array.Sort() function
            Array.Sort(insertToTreeArr);
            foreach (var num in insertToTreeArr)
            {
                //for each number in insertToTreeArr, add to the BinaryTree Class
                tree.Insert(num);
            }
        }

    }

    private static void Part3() {
        throw new NotImplementedException();
    }
}
public class TreeNode
{
    //public int Level; 
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
    }
    public TreeNode ConvertToBinarySearchTree(List<int> randomList, int start, int end)
    {

        if (start > end) return null;

        int mid = (start + end) / 2;

        TreeNode node = new TreeNode(randomList[mid]);

        node.Left = ConvertToBinarySearchTree(randomList, start, mid - 1);
        node.Right = ConvertToBinarySearchTree(randomList, mid + 1, end);

        return node;
    }

}
//TreeNode root = ConvertToBinarySearchTree(randomList, 0, randomList.Count - 1);

/*[TestMethod]
 * public void Insert1NodeFillsRootProperty()
 * {
 *      BinaryTree tree = new BinaryTree();
 *      BinaryTree tree2 = new BinaryTree(7);
 *      
 *      tree.Insert(5);
 *      
 *      Assert.AreEqual(tree.Root.value, 5);
 *      Assert.AreEqual(tree2.Root.value, 7);
 * }
 * 
 * [TestMethod]
 * 
 */
 
/* Node class
 * -int value
 * -Node? leftChild
 * -Node? rightChild
 * -IsLeaf     (IsRoot being false would tell us IsLeaf)
 * -IsRoot
 * int Level */


/* Tree class
 *  - Node? root
 *  - List<TreeNode>
 * - AddNode()
 *  - GetNode()
 *  */
public class BinaryTree
{
       public TreeNode Root;
    //constructor with no param sets root to null
    public BinaryTree()
    {
        Root = null;
    }
    //constructor with int param sets the root to that value
    public BinaryTree(int value)
    {
        Root = new TreeNode(value);
    }
       
       //insert method to find a position for each Node
       public void Insert(int value)
       {
           // *** our initial root node == null, so currently this function will return 1 node without recursing (remove this comment when fixed)
           Root = InsertValueToTree(Root, value);   
       }
       
       //method to insert into tree based on position
       public TreeNode InsertValueToTree(TreeNode node, int value)
       {
           //if the tree is empty, the first node becomes the root
           if(node == null)
           {
                return new TreeNode(value);
           }
           //if the tree is not empty - if the value is less than the current node, go left, else go right
           else
           {
                if(value < node.Value)
                {
                //go left
                node.Left = InsertValueToTree(node.Left, value);
                }
                else
                {
                //go right
                node.Right = InsertValueToTree(node.Right, value);
                }
           }

        return node;
       }

    //method to determine if tree contains the value
    public bool Contains(int value)
    {
        //if the tree contains the passed value, return true
        //GetNode returns either a node or null
        return GetNode(Root, value) != null;
    }
        
        //method to find node
    public TreeNode GetNode(TreeNode n, int valueToSearch)
    {
        //n is the current node through iteration, starting with the root
        //if root is null, tree is empty
        if (n == null) { return null; }
        //if the current node's value matches value to search for, return that node
        //break out of recursion if value is found OR if we are at the end of the tree
        if (n.Value == valueToSearch)
        {
            return n;
        }
        //return null if we are at the end of the tree and value hasn't been found
        if(n.Left == null && n.Right == null) { return null; }
        //if its not found and the value is less than n's current value, recursively call GetNode using the leftChild
        else if (valueToSearch < n.Value)
        {
            return GetNode(n.Left, valueToSearch);
        }
        else //(valueToSearch > n.Value) //do the same as above but traversing the right children for values greater than current node's value
        {
            return GetNode(n.Right, valueToSearch);
        }
        
    }
}











//-Generate Random 1000 integer
//And Sort it, and then reverse it.

//-Generate Random 1000 integer
//And Sort it, and then build a binary tree.

//-Generate 100 integer,
//Use the binary tree to see if some value is present.
//Prepare dictionary<bool,int[]> 
//true=> present results
//false=> not present results
