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

        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            
            //Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);            
        }

        [TestMethod]
        public void TestRecordTypeCanHaveMutableProperties()
        {
            string expected = "NewString";
            SampleRecord record1 = 
                new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5)) {  MutableProperty="InitialString" };
            record1.MutableProperty = expected;
            Assert.AreEqual(record1.MutableProperty, expected);
        }
    }
}