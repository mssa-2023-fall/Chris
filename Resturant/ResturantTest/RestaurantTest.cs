using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestaurantTest
{
    [TestClass]
    public class ProteinSelection
    {
        Restaurant menu;
        

            [TestInitialize]
            public void TestSetup()
            {
                Restaurant menu = new Restaurant();
            }

            [TestMethod]
            [DataRow("Beef", "hamburger")]
            [DataRow("Pepperoni", "pizza")]
            [DataRow("Tofu", "tofu fried rice")]
            [DataRow("BEEF", "hamburger")]
            [DataRow("PEPPERoni", "pizza")]
            [DataRow("tofu", "tofu fried rice")]
            public void TestWithExpectedProteinTypeShouldReturnCorrespondingDishes(string proteinChoices, string expectedDish)
            {
                string actualDish = menu.DishOptions(proteinChoices);
                Assert.AreEqual(expectedDish, actualDish, true, "Expected dish does not match actual dish.");
            }

            [TestMethod]
            public void TestWith_UNExpected_ProteinTypeShouldReturnMessageProteinNotAvailable()
            {
                string actualDish = menu.DishOptions("somethingRandom");
                Assert.AreEqual("That protein is not available.", actualDish, true, "Expected message does not match actual message.");
            }
    }
}
