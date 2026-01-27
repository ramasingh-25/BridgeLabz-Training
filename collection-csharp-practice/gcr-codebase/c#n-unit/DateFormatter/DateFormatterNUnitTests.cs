using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class DateFormatterNUnitTests
    {
        private DateFormatter formatter;

        [SetUp]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [Test]
        public void Valid_Date_Should_Format_Correctly()
        {
            string result = formatter.FormatDate("2024-01-15");
            Assert.AreEqual("15-01-2024", result);
        }

        [Test]
        public void Invalid_Date_Should_Return_Error_Message()
        {
            string result = formatter.FormatDate("15/01/2024");
            Assert.AreEqual("Invalid Date", result);
        }
    }
}
