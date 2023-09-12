using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [TestClass]
    public class CarStackWithLinkedListTests
    {
        [TestMethod]
        public void TestPush()
        {
            CarStackWithLinkedList<string> carStack = new CarStackWithLinkedList<string>();
            carStack.Push("Mustang");
            carStack.Push("Corvette");
            carStack.Push("Bronco");
            Assert.AreEqual(3, carStack.Count);
        }

        [TestMethod]
        public void TestPop()
        {
            CarStackWithLinkedList<string> carStack = new CarStackWithLinkedList<string>();
            carStack.Push("Mustang");
            carStack.Push("Corvette");
            carStack.Push("Bronco");
            carStack.Pop();
            carStack.Pop();
            Assert.AreEqual(1, carStack.Count);
            Assert.AreEqual("Mustang", carStack.Peek());
        }

        [TestMethod]
        public void TestClear()
        {
            CarStackWithLinkedList<string> carStack = new CarStackWithLinkedList<string>();
            carStack.Push("Mustang");
            carStack.Push("Corvette");
            carStack.Push("Bronco");
            carStack.Clear();
            Assert.AreEqual(0, carStack.Count);
        }

        [TestMethod]
        public void TestPeek()
        {
            CarStackWithLinkedList<string> carStack = new CarStackWithLinkedList<string>();
            carStack.Push("Mustang");
            carStack.Push("Corvette");
            carStack.Push("Bronco");
            Assert.AreEqual("Bronco", carStack.Peek());
        }
    }
}