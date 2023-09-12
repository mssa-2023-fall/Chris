using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestQueue
{
    [TestClass]
    public class CarStack
    {

        private Stack<string> carStack = new Stack<string>();

        public void Push(string car)
        {
            carStack.Push(car);
        }

        public void Pop()
        {
            carStack.Pop();
        }

        public string Peek()
        {
            return carStack.Peek();
        }

        public int Count()
        {
            return carStack.Count();
        }
    }


    [TestClass]
    public class CarStackTests
    {
        [TestMethod]
        public void TestPush()
        {
            CarStack carStack = new CarStack();
            carStack.Push("Mustang");
            carStack.Push("Corvette");
            carStack.Push("Bronco");
            Assert.AreEqual(3, carStack.Count());
        }

        [TestMethod]
        public void TestPop()
        {
            CarStack carStack = new CarStack();
            carStack.Push("Mustang");
            carStack.Push("Corvette");
            carStack.Push("Bronco");
            carStack.Pop();
            carStack.Pop();
            Assert.AreEqual(1, carStack.Count());
            Assert.AreSame(carStack.Peek(), "Mustang");
        }
    }
}