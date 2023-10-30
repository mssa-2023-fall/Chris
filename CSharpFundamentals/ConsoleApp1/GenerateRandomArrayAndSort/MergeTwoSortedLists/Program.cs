using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }


    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            int[] arr1 = ListToArray(list1);
            int[] arr2 = ListToArray(list2);

            int[] mergedArray = MergeArray(arr1, arr2);

            return ArrayToListNode(mergedArray);

            
        }

        public int[] ListToArray(ListNode node)
        {
            List<int> list = new List<int>();
            while (node != null)
            {
                list.Add(node.val);
                node = node.next;
            }
            return list.ToArray();
        }

        public int[] MergeArray(int[] arr1, int[] arr2)
        {
            int[] mergedArray = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                mergedArray[i] = arr1[i];
            }

            for (int i = 0;i < arr2.Length; i++)
            {
                mergedArray[arr1.Length + i] = arr2[i];
            }

            Array.Sort(mergedArray);
            return mergedArray;
        }

        public ListNode ArrayToListNode(int[] arr)
        {
            if (arr.Length == 0) return null;

            ListNode head = new ListNode(arr[0]);
            ListNode current = head;

            for (int i = 1; i < arr.Length; i++)
            {
                current.next = new ListNode(arr[i]);
                current = current.next;
            }

            return head;
        }
        
    }

