using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void Add_Test()
        {
            Assert.AreEqual(10, calc.Add(5, 5));
        }

        [Test]
        public void Subtract_Test()
        {
            Assert.AreEqual(2, calc.Subtract(5, 3));
        }

        [Test]
        public void Multiply_Test()
        {
            Assert.AreEqual(15, calc.Multiply(5, 3));
        }

        [Test]
        public void Divide_Test()
        {
            Assert.AreEqual(2, calc.Divide(10, 5));
        }

        [Test]
        public void Divide_By_Zero_Test()
        {
            Assert.Throws<DivideByZeroCustomException>(() => calc.Divide(10, 0));
        }
    }
}
