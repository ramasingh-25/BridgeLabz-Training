using NUnit.Framework;
using Calculator;   

namespace Calculator.Tests
{
    [TestFixture]
    public class StringUtilsNUnitTests
    {
        private StringUtils utils;

        [SetUp]
        public void Setup()
        {
            utils = new StringUtils();
        }

        [Test]
        public void Reverse_Test()
        {
            Assert.AreEqual("olleh", utils.Reverse("hello"));
        }

        [Test]
        public void Palindrome_Test()
        {
            Assert.IsTrue(utils.IsPalindrome("madam"));
        }

        [Test]
        public void UpperCase_Test()
        {
            Assert.AreEqual("HELLO", utils.ToUpperCase("hello"));
        }
    }
}
