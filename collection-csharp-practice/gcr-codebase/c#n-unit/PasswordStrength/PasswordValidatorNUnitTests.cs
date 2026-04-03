using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class PasswordValidatorNUnitTests
    {
        private PasswordValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [Test]
        public void Valid_Password_Should_Return_True()
        {
            Assert.IsTrue(validator.IsValid("Password1"));
        }

        [Test]
        public void Password_Without_Uppercase_Should_Fail()
        {
            Assert.IsFalse(validator.IsValid("password1"));
        }

        [Test]
        public void Password_Without_Digit_Should_Fail()
        {
            Assert.IsFalse(validator.IsValid("Password"));
        }

        [Test]
        public void Password_With_Less_Than_8_Characters_Should_Fail()
        {
            Assert.IsFalse(validator.IsValid("Pass1"));
        }
    }
}
