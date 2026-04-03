using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class TemperatureConverterNUnitTests
    {
        private TemperatureConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [Test]
        public void Celsius_To_Fahrenheit_Test()
        {
            Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
            Assert.AreEqual(212, converter.CelsiusToFahrenheit(100));
        }

        [Test]
        public void Fahrenheit_To_Celsius_Test()
        {
            Assert.AreEqual(0, converter.FahrenheitToCelsius(32));
            Assert.AreEqual(100, converter.FahrenheitToCelsius(212));
        }
    }
}
