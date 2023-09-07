using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplementation
{
    public class ChrisLinkedList<T> : ILinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        
        public INode<T> Head { get { return head; } }
        public INode<T> Tail { get { return tail; } }
        public IEnumerable<INode<T>> Nodes
        {
            get
            {
                List<INode<T>> nodeList = new List<INode<T>>();

                Node<T> current = head;
                while (current != null)
                {
                    nodeList.Add(current);
                    current = current.NextNode;
                }

                return nodeList;
            }
        }
        public int Count { get; private set; }

        public void AddFirst(INode<T> value)
        {
           Node<T> addNode = value as Node<T>;
            addNode.NextNode = head;
            head = addNode;

            if (tail == null)
            {
                tail = head;
            }
            Count++;
        }

        public void InsertAfterNodeIndex(INode<T> value, int position)
        {
            if (position == 0)
            {
                AddFirst(value);
            }

            Node<T> thisNode = head;
            for (int i = 1; i <= position; i++)
            {
                thisNode = thisNode.NextNode;
            }
            Node<T> newNode = value as Node<T>;
            newNode.NextNode = thisNode.NextNode;
            thisNode.NextNode = newNode;

            if(newNode.NextNode == null)
            { 
                tail = newNode; 
            }
            Count++;

        }
        public void AddLast(INode<T> value)
        {
            Node<T> newNode = value as Node<T>;
            if(tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.NextNode = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.NextNode;
                Count--;
            }
        }
        public void RemoveAt(int IndexPosition)
        {
            if (IndexPosition == 0)
            {
                RemoveFirst();
                return;
            }
            Node<T> thisNode = head;
            for (int i = 1; i < IndexPosition; i++)
            {
                thisNode = thisNode.NextNode;
            }
                thisNode.NextNode = thisNode.NextNode.NextNode;
            if (thisNode.NextNode == null)
            {
                tail = thisNode;
            }
            Count--;
        }
        
        public void RemoveLast()
        {
            Node<T> thisNode = head;
            while (thisNode.NextNode != tail)
            {
                thisNode = thisNode.NextNode;
            }
            tail = thisNode;
            thisNode.NextNode = null;
            Count--;
        }
        public INode<T>? FindFirst(T value)
        {
            Node<T> thisNode = head;
            while (thisNode != null)
            {
                if (thisNode.Content.Equals(value))
                {
                    return thisNode;
                }
                thisNode = thisNode.NextNode;
            }
            return null;
        }

        public INode<T>[] FindAll(T value)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            Node<T> thisNode = head;
            while (thisNode != null)
            {
            if (thisNode.Content.Equals(value))
                {
                    nodes.Add(thisNode);
                }
            thisNode = thisNode.NextNode;
            }
            return nodes.ToArray();
        }

        private class Node<T> : INode<T>
        {
            public T Content { get; set; }
            public Node<T> NextNode { get; set; }

            public INode<T>? Next() => NextNode;

            public Node(T content)
            {
                Content = content;
                NextNode = null;
            }
        }
    }
}
