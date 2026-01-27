using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class DatabaseConnectionMSTests
    {
        private DatabaseConnection db;

        // Runs BEFORE each test
        [TestInitialize]
        public void Setup()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        // Runs AFTER each test
        [TestCleanup]
        public void Cleanup()
        {
            db.Disconnect();
        }

        [TestMethod]
        public void Connection_Should_Be_Established()
        {
            Assert.IsTrue(db.IsConnected);
        }

        [TestMethod]
        public void Connection_Should_Be_Closed_After_Cleanup()
        {
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
