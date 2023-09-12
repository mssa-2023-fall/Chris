using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BinarySearchTest
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void SearchReturnsCorrectValue()
        {
            int[] array = new int[1000000];
            int target = 777666;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            int result = BinarySearch.binarySearch(array, target);

            Assert.AreEqual(777666, result);
        }

        [TestMethod]
        public void NotFoundReturnsMinusOne()
        {
            int[] array = { 1, 2, 3 };
            int target = 777666;

            int result = BinarySearch.binarySearch(array, target);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void EmptyArrayReturnsMinusOne()
        {
            int[] array = { };
            int target = 7;

            int result = BinarySearch.binarySearch(array, target);

            Assert.AreEqual(-1, result);
        }


        [TestMethod]
        public void BinarySearchDuplicateElementsReturnsFirstCorrectValue()
        {
            int[] array = { 1, 2, 3, 3, 3, 4, 5 };
            int target = 2;

            int result = BinarySearch.binarySearch(array, target);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SingleItemArrayWorks()
        {
            int[] array = { 7 };
            int targetInArray = 7;
            int targetNotInArray = 777;

            //Single item is in array and returns index 0
            int result = BinarySearch.binarySearch(array, targetInArray);
            Assert.AreEqual(0, result); 

            //Single item is not in the array and returns -1
            int resultNotPresent = BinarySearch.binarySearch(array, targetNotInArray);
            Assert.AreEqual(-1, resultNotPresent);
        }
    }
}