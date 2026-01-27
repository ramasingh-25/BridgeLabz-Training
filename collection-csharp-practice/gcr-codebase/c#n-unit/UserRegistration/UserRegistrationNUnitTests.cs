using NUnit.Framework;
using Calculator;
using System;

namespace Calculator.Tests
{
    [TestFixture]
    public class UserRegistrationNUnitTests
    {
        private UserRegistration registration;

        [SetUp]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [Test]
        public void Valid_User_Registration_Should_Pass()
        {
            Assert.DoesNotThrow(() =>
                registration.RegisterUser("john", "john@gmail.com", "Password1"));
        }

        [Test]
        public void Empty_Username_Should_Fail()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("", "john@gmail.com", "Password1"));
        }

        [Test]
        public void Invalid_Email_Should_Fail()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "johngmail.com", "Password1"));
        }

        [Test]
        public void Short_Password_Should_Fail()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "john@gmail.com", "pass"));
        }
    }
}
    