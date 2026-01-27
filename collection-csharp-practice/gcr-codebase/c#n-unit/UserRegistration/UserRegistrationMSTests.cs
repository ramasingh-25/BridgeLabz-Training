using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class UserRegistrationMSTests
    {
        private UserRegistration registration;

        [TestInitialize]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [TestMethod]
        public void Valid_User_Registration_Should_Pass()
        {
            registration.RegisterUser("john", "john@gmail.com", "Password1");
            Assert.IsTrue(true); // reached means success
        }

        [TestMethod]
        public void Empty_Username_Should_Fail()
        {
            try
            {
                registration.RegisterUser("", "john@gmail.com", "Password1");
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Invalid_Email_Should_Fail()
        {
            try
            {
                registration.RegisterUser("john", "johngmail.com", "Password1");
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Short_Password_Should_Fail()
        {
            try
            {
                registration.RegisterUser("john", "john@gmail.com", "pass");
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
