using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class StringUtilsMSTests
    {
        private Calculator.StringUtils utils;

        [TestInitialize]
        public void Setup()
        {
            utils = new Calculator.StringUtils();
        }

        [TestMethod]
        public void Reverse_Test()
        {
            Assert.AreEqual("olleh", utils.Reverse("hello"));
        }

        [TestMethod]
        public void Palindrome_Test()
        {
            Assert.IsTrue(utils.IsPalindrome("madam"));
        }

        [TestMethod]
        public void UpperCase_Test()
        {
            Assert.AreEqual("HELLO", utils.ToUpperCase("hello"));
        }
    }
}
