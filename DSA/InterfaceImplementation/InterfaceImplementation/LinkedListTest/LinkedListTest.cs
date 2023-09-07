using LinkedList;
using InterfaceImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedListTest
{
    [TestClass]
    public class ChrisLinkedListTest
    {
        [TestMethod]
        public void DefaultConstructorCreatesEmptyLL()
        {
            var testLL = new ChrisLinkedList<int>();
            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }

        [TestMethod]
        public void EmptyLLCallingRemoveShouldThrowInvalidOperationException()
        {
            var testLL = new ChrisLinkedList<int>();
            int exceptionCount = 0;

            try
            {
                testLL.RemoveLast();
            }
            catch (InvalidOperationException)
            {
                exceptionCount++;
            }

            try
            {
                testLL.RemoveAt(0);
            }
            catch (InvalidOperationException)
            {
                exceptionCount++;
            }

            Assert.AreEqual(2, exceptionCount, "Expected InvalidOperationException was not thrown for one or more methods.");
            Assert.AreEqual(0, testLL.Count, "List count should remain 0 after exception-causing operations.");
        }

        [TestMethod]
        public void AddFirstShouldReplaceHeadNodeAndCreateLinkToOldHead()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            var addFirstNode = new ChrisLinkedList<int>.Node<int>(10);
            testLL.AddFirst(addFirstNode);

            Assert.AreEqual(2, testLL.Count);
            Assert.AreEqual(testLL.Head.Content, addFirstNode.Content);
            Assert.AreEqual(testLL.Tail.Content, initialNode.Content);
        }

        [TestMethod]
        public void AddLastShouldAddNodeAtTheEnd()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            var addLastNode = new ChrisLinkedList<int>.Node<int>(10);
            testLL.AddLast(addLastNode);

            Assert.AreEqual(2, testLL.Count);
            Assert.AreEqual(testLL.Head.Content, initialNode.Content);
            Assert.AreEqual(testLL.Tail.Content, addLastNode.Content);
        }

        [TestMethod]
        public void InsertAfterNodeIndexShouldAddNodeAfterGivenPosition()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            var addAfterNode = new ChrisLinkedList<int>.Node<int>(10);
            testLL.InsertAfterNodeIndex(addAfterNode, 0);

            Assert.AreEqual(2, testLL.Count);
            Assert.AreEqual(testLL.Head.Content, initialNode.Content);
            Assert.AreEqual(testLL.Tail.Content, addAfterNode.Content);
            Assert.AreEqual(testLL.Head.Next().Content, addAfterNode.Content);
        }

        [TestMethod]
        public void ClearMethodShouldReturnEmptyLinkedList()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            var addLastNode = new ChrisLinkedList<int>.Node<int>(10);
            testLL.AddLast(addLastNode);

            testLL.Clear();
            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }

        [TestMethod]
        public void FindAllMethodShouldReturnNullIfNotFound()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(6));
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(7));

            var result = testLL.FindAll(1);

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void FindAllMethodShouldReturnOne()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(6));
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(7));

            var result = testLL.FindAll(5);

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(result[0].Content, 5);
        }

        [TestMethod]
        public void FindAllMethodShouldReturnMany()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(6));
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(7));
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(5));

            var result = testLL.FindAll(5);

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(result[0].Content, 5);
            Assert.AreEqual(result[1].Content, 5);
        }

        [TestMethod]
        public void FindOneMethodShouldReturnExactlyOneEvenIfThereAreMultipleMatches()
        {
            var initialNode = new ChrisLinkedList<int>.Node<int>(5);
            var testLL = new ChrisLinkedList<int>();
            testLL.AddFirst(initialNode);
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(6));
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(7));
            testLL.AddFirst(new ChrisLinkedList<int>.Node<int>(5));

            var result = testLL.FindFirst(5);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, 5);
        }
    }
}