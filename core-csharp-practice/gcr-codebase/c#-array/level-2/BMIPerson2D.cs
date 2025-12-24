using System;

namespace Project1.array
{
    class BMIofPerson2D
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter number of persons:");
            int number = int.Parse(Console.ReadLine());


            double[][] personData = new double[number][];
            string[] weightStatus = new string[number];

            for (int i = 0; i < number; i++)
            {
                personData[i] = new double[3];

                Console.WriteLine("\nPerson " + (i + 1));

                // Weight input
                Console.Write("Enter weight (kg): ");
                personData[i][0] = Convert.ToDouble(Console.ReadLine());
                if (personData[i][0] <= 0)
                {
                    Console.WriteLine("Weight must be positive.");
                    i--;
                    continue;
                }


                Console.Write("Enter height (cm): ");
                personData[i][1] = Convert.ToDouble(Console.ReadLine()) / 100;
                if (personData[i][1] <= 0)
                {
                    Console.WriteLine("Height must be positive.");
                    i--;
                    continue;
                }

                // Calculate BMI
                personData[i][2] =
                    personData[i][0] / (personData[i][1] * personData[i][1]);


                if (personData[i][2] < 18.5)
                    weightStatus[i] = "Underweight";
                else if (personData[i][2] < 25)
                    weightStatus[i] = "Normal";
                else if (personData[i][2] < 30)
                    weightStatus[i] = "Overweight";
                else
                    weightStatus[i] = "Obese";
            }


            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("\nPerson " + (i + 1));
                Console.WriteLine("Weight : " + personData[i][0] + " kg");
                Console.WriteLine("Height : " + personData[i][1] + " m");
                Console.WriteLine("BMI    : " + personData[i][2].ToString("F2"));
                Console.WriteLine("Status : " + weightStatus[i]);
            }
        }
    }
}