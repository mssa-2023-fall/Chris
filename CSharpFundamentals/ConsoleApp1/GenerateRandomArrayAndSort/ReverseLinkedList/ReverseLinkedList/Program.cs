﻿
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }
 


public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        
        ListNode current = head;
        ListNode previous = null;
        ListNode next = null;
        
        while (current != null)
        {
            next = current.next;
            current.next = previous;

            previous = current;
            current = next;
        }
        return previous;
    }
}