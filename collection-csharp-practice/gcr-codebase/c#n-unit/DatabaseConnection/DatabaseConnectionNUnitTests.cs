using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class DatabaseConnectionNUnitTests
    {
        private DatabaseConnection db;

        // Runs BEFORE each test
        [SetUp]
        public void Setup()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        // Runs AFTER each test
        [TearDown]
        public void TearDown()
        {
            db.Disconnect();
        }

        [Test]
        public void Connection_Should_Be_Established()
        {
            Assert.IsTrue(db.IsConnected);
        }

        [Test]
        public void Connection_Should_Be_Closed_After_TearDown()
        {
            // Disconnect manually to simulate end
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
