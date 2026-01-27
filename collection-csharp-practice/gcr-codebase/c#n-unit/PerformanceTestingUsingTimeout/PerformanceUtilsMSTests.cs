using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class PerformanceUtilsMSTests
    {
        private PerformanceUtils utils;

        [TestInitialize]
        public void Setup()
        {
            utils = new PerformanceUtils();
        }

        // Test will FAIL if execution exceeds 2 seconds
        [TestMethod]
        [Timeout(2000)]
        public void LongRunningTask_Should_Timeout()
        {
            utils.LongRunningTask();
        }
    }
}
