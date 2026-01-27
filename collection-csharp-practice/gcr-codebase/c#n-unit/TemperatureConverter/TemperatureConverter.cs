namespace Calculator
{
    // Converts temperature between Celsius and Fahrenheit
    public class TemperatureConverter
    {
        // C to F: (C × 9/5) + 32
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // F to C: (F − 32) × 5/9
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}

