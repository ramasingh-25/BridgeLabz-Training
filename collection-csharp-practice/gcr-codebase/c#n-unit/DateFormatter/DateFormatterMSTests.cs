using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class DateFormatterMSTests
    {
        private DateFormatter formatter;

        [TestInitialize]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [TestMethod]
        public void Valid_Date_Should_Format_Correctly()
        {
            string result = formatter.FormatDate("2024-01-15");
            Assert.AreEqual("15-01-2024", result);
        }

        [TestMethod]
        public void Invalid_Date_Should_Return_Error_Message()
        {
            string result = formatter.FormatDate("15/01/2024");
            Assert.AreEqual("Invalid Date", result);
        }
    }
}
