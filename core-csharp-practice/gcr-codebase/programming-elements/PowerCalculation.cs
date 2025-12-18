using System;

public class PowerCalculation {
    public static void Main(String[] args) {
		
        double baseNum = 5.0;
        double exponent = 3.0;

        double result = Math.Pow(baseNum, exponent);

        Console.WriteLine("Result=" + result ); 
    }
}