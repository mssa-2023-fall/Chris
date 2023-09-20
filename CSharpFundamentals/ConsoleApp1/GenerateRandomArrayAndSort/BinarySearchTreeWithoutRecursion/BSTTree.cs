using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeWithoutRecursion
{
    public class BSTTree
    {
        public BSTNode root;

        public void BuildTheTree(int value)
        {
            BSTNode newNode = new BSTNode(value);

            if (root == null)
            {
                root = newNode;
                return;
            }
            BSTNode current = root;
            BSTNode? parent = null;
            while (true)
            {
                parent = current;

                if (value < current.Value)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }
    }
}
