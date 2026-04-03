using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class ExceptionUtilsNUnitTests
    {
        private ExceptionUtils utils;

        [SetUp]
        public void Setup()
        {
            utils = new ExceptionUtils();
        }

        [Test]
        public void Divide_By_Zero_Should_Throw_Exception()
        {
            Assert.Throws<ArithmeticException>(() => utils.Divide(10, 0));
        }

        [Test]
        public void Divide_Valid_Input_Should_Return_Result()
        {
            Assert.AreEqual(5, utils.Divide(10, 2));
        }
    }
}
