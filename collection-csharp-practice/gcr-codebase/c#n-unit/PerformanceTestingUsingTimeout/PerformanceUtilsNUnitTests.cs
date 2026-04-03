using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class PerformanceUtilsNUnitTests
    {
        private PerformanceUtils utils;

        [SetUp]
        public void Setup()
        {
            utils = new PerformanceUtils();
        }

        // Test will FAIL if execution exceeds 2 seconds
        [Test]
        [Timeout(2000)]
        public void LongRunningTask_Should_Timeout()
        {
            utils.LongRunningTask();
        }
    }
}
