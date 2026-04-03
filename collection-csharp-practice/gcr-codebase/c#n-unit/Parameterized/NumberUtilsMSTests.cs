using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class NumberUtilsMSTests
    {
        private NumberUtils utils;

        [TestInitialize]
        public void Setup()
        {
            utils = new NumberUtils();
        }

        // Parameterized test using DataRow
        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_Test(int number, bool expected)
        {
            Assert.AreEqual(expected, utils.IsEven(number));
        }
    }
}
