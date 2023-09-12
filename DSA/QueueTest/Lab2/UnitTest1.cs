namespace Lab2
{
    [TestClass]
    public class Lab3
    {
        Queue<string> carQueue = new Queue<string>();


        [TestMethod]
        public void QueueCountMatchesEnqueueQuantity()
        {
            carQueue.Enqueue("Mustang");
            carQueue.Enqueue("Corvette");
            carQueue.Enqueue("Model S");
            Assert.AreEqual(3, carQueue.Count);
        }

        [TestMethod]
        public void QueueCountMatchesAfterDequeue()
        {
            carQueue.Enqueue("Mustang");
            carQueue.Enqueue("Corvette");
            carQueue.Enqueue("Model S");
            carQueue.Dequeue();
            carQueue.Dequeue();

            Assert.AreEqual(1, carQueue.Count);
            Assert.AreEqual("Model S", carQueue.Peek());
        }

        [TestMethod]
        public void IterateThroughQueueAndReturnItemsInFIFOOrder()
        {
            carQueue.Enqueue("Mustang");
            carQueue.Enqueue("Corvette");
            carQueue.Enqueue("Model S");

            while (carQueue.Count > 0)
            {
                string dequeued = carQueue.Dequeue();
                Console.WriteLine($"Dequeued {dequeued}");
            }
        }
    }
}