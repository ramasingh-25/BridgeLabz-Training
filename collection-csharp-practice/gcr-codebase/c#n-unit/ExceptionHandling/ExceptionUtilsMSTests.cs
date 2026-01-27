using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ExceptionUtilsMSTests
    {
        private ExceptionUtils utils;

        [TestInitialize]
        public void Setup()
        {
            utils = new ExceptionUtils();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Divide_By_Zero_Should_Throw_Exception()
        {
            utils.Divide(10, 0);
        }

        [TestMethod]
        public void Divide_Valid_Input_Should_Return_Result()
        {
            Assert.AreEqual(5, utils.Divide(10, 2));
        }
    }
}
