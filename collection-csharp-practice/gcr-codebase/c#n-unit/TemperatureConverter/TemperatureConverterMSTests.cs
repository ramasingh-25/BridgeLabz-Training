using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class TemperatureConverterMSTests
    {
        private TemperatureConverter converter;

        [TestInitialize]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [TestMethod]
        public void Celsius_To_Fahrenheit_Test()
        {
            Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
            Assert.AreEqual(212, converter.CelsiusToFahrenheit(100));
        }

        [TestMethod]
        public void Fahrenheit_To_Celsius_Test()
        {
            Assert.AreEqual(0, converter.FahrenheitToCelsius(32));
            Assert.AreEqual(100, converter.FahrenheitToCelsius(212));
        }
    }
}
