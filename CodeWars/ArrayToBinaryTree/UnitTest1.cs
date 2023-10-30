using System;

namespace ArrayToBinaryTree;


class Solution
{
    public static TreeNode ArrayToTree(int[] arr, int i = 0)
    {
        if (i >= arr.Length)
            return null;

        TreeNode currentNode = new TreeNode(arr[i]);
        currentNode.left = ArrayToTree(arr, 2 * i + 1);
        currentNode.right = ArrayToTree(arr, 2 * i + 2);

        return currentNode;
    }
}
class TreeNode
{

    public TreeNode left;
    public TreeNode right;
    public int value;

    public TreeNode(int value, TreeNode left, TreeNode right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }

    public TreeNode(int value)
    {
        this.value = value;
    }
}