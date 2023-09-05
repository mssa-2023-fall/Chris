namespace LearnImmutableTest
{
    [TestClass]
    public class SampleRecordTest
    {
        [TestMethod]
        public void TestRecordTypeEqualityWithPositionPerameters()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            
            //Assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }

        [TestMethod]
        public void TestRecordTypeInEqualityWithPositionPerameters()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            //Assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }

        [TestMethod]
        public void TestRecordTypeSamenessWithPositionPerameters()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = record1;

            //Assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);
        }
    }
}