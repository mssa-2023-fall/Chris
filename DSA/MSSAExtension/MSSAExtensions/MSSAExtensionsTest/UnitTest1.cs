using MssaExtension;
using System.Linq;
namespace MssaExtensionsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetShaStringExtension()
        {
            var _file = new FileInfo(@"C:\test\oscar_age_male.csv");
            var _file2 = new FileInfo(@"C:\test\a.png");

            Assert.AreEqual("rSSHX5rkP6Y4BrmT3rYYmGmqInc=", _file.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("ad24875f9ae43fa63806b993deb6189869aa2277", _file.GetSHAString(StringFormat.Hex));
            Assert.AreEqual("UvJGiou9cFFxRVBB74rk9kLyIWA=", _file2.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("52f2468a8bbd705171455041ef8ae4f642f22160", _file2.GetSHAString(StringFormat.Hex));
        }

        [TestMethod]
        public void CustomLinqMethods1()
        {
            IEnumerable<int> inputs1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<double> inputs2 = new[] { 1.5, 2.3, 3.1, 4.78, 5.72, 6.12, 7.99, 8.26 };
            float median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(4, median);
            median = inputs2.Median();
            Assert.AreEqual(5.25, median);
        }

        [TestMethod]
        public void CustomLinqMethods2()
        {
            IEnumerable<decimal> inputs1 = new[] { 1.5m, 2.3m, 3.1m, 4.78m, 5.72m, 6.12m, 7.99m, 8.26m };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.25, median);
        }
        [TestMethod]
        public void CustomLinqMethods3()
        {
            IEnumerable<float> inputs1 = new[] { 1.5f, 2.3f, 3.1f, 4.78f, 5.72f, 6.12f, 7.99f, 8.26f };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.25f, median);
        }

        [TestMethod]
        public void TestDictionaryIndexer()
        {
            Dictionary<FileInfo, Stream> dictionary = new Dictionary<FileInfo, Stream>();
            var _file = new FileInfo(@"""C:\test\oscar_age_male.csv""");
            dictionary.Add(_file, _file.OpenRead());
            Assert.IsTrue(dictionary[_file].Length == _file.Length);
        }
    }
}