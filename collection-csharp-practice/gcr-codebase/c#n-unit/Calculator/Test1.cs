using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator.Calculator calc;

        [TestInitialize]
        public void Setup()
        {
            calc = new Calculator.Calculator();
        }

        [TestMethod]
        public void Add_Test()
        {
            Assert.AreEqual(10, calc.Add(5, 5));
        }

        [TestMethod]
        public void Subtract_Test()
        {
            Assert.AreEqual(2, calc.Subtract(5, 3));
        }

        [TestMethod]
        public void Multiply_Test()
        {
            Assert.AreEqual(15, calc.Multiply(5, 3));
        }

        [TestMethod]
        public void Divide_Test()
        {
            Assert.AreEqual(2, calc.Divide(10, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(Calculator.DivideByZeroCustomException))]
        public void Divide_By_Zero_Test()
        {
            calc.Divide(10, 0);
        }
    }
}
