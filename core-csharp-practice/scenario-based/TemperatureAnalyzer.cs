using System;
using System.Collections.Generic;
using System.Text;

namespace project1.ScenarioBased
{
    class TemperatureAnalyzer
    {
        
        static void hourlyTemperature(float[,] temperatures)
        {
            int hottestDay = 0;
            int coldestDay = 0;

            float hottestTemperature = temperatures[0, 0];
            float coldestTemperature = temperatures[0, 0];

            float[] dailyAverage = new float[7];

            for (int day = 0; day < 7; day++)
            {
                float sum = 0;

                for (int hour = 0; hour < 24; hour++)
                {
                    float temp = temperatures[day, hour];
                    sum += temp;

                    if (temp > hottestTemperature)
                    {

                        hottestTemperature = temp;
                        hottestDay = day;

                    }

                    if (temp < coldestTemperature)
                    {
                        coldestTemperature = temp;
                        coldestDay = day;
                    }
                }

                dailyAverage[day] = sum / 24;
            }
            //for average temperature
            Console.WriteLine("Average temperature per day:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1}: {dailyAverage[i]:F2}°C");
            }
            //for hottest temperature
            Console.WriteLine($"\nHottest Day: Day {hottestDay + 1} ({hottestTemperature}°C)");
            //for coldest temperature
            Console.WriteLine($"Coldest Day: Day {coldestDay + 1} ({coldestTemperature}°C)");
        }

        static void Main()
        {
            float[,] temperatures = new float[7, 24]
            {
            { 22,23,21,20,19,18,17,18,20,22,24,26,28,29,30,29,28,27,26,25,24,23,22,21 },
            { 21,22,20,19,18,17,16,17,19,21,23,25,27,28,29,28,27,26,25,24,23,22,21,20 },
            { 23,24,22,21,20,19,18,19,21,23,25,27,29,30,31,30,29,28,27,26,25,24,23,22 },
            { 20,21,19,18,17,16,15,16,18,20,22,24,26,27,28,27,26,25,24,23,22,21,20,19 },
            { 24,25,23,22,21,20,19,20,22,24,26,28,30,31,32,31,30,29,28,27,26,25,24,23 },
            { 19,20,18,17,16,15,14,15,17,19,21,23,25,26,27,26,25,24,23,22,21,20,19,18 },
            { 22,23,21,20,19,18,17,18,20,22,24,26,28,29,30,29,28,27,26,25,24,23,22,21 }
            };

            hourlyTemperature(temperatures);
        }
    }

}