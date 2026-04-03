using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class PasswordValidatorMSTests
    {
        private PasswordValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [TestMethod]
        public void Valid_Password_Should_Return_True()
        {
            Assert.IsTrue(validator.IsValid("Password1"));
        }

        [TestMethod]
        public void Password_Without_Uppercase_Should_Fail()
        {
            Assert.IsFalse(validator.IsValid("password1"));
        }

        [TestMethod]
        public void Password_Without_Digit_Should_Fail()
        {
            Assert.IsFalse(validator.IsValid("Password"));
        }

        [TestMethod]
        public void Password_With_Less_Than_8_Characters_Should_Fail()
        {
            Assert.IsFalse(validator.IsValid("Pass1"));
        }
    }
}
