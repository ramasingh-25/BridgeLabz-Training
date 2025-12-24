using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.array
{
    public class BMIPerson
    {
        public static void Main(string[] args)
        {
            //enter number of person
            Console.WriteLine("Enter number of person");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] weight = new double[n];
            double[] height = new double[n];
            double[] bmi = new double[n];
            string[] status = new string[n];

            Console.WriteLine("Enter weight and hieght of Person");
            for (int i = 0; i < n; i++)
            {
                //input weight
                Console.WriteLine("Enter weight ");
                weight[i] = Convert.ToDouble(Console.ReadLine());

                //input height
                Console.WriteLine("Enter height ");
                height[i] = Convert.ToDouble(Console.ReadLine());

            }

            //BMI status
            for (int i = 0; i <n ; i++)
            {
                bmi[i] = weight[i] / (height[i] * height[i]);

                if (bmi[i] < 18.5)
                    status[i] = "Underweight";

                else if (bmi[i] < 25)
                    status[i] = "Normal";

                else if (bmi[i] < 30)
                    status[i] = "Overweight";

                else
                    status[i] = "Obese";
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nPerson " + (i + 1));

                Console.WriteLine("Height : " + height[i] + " m");

                Console.WriteLine("Weight : " + weight[i] + " kg");

                Console.WriteLine("BMI    : " + bmi[i].ToString("F2"));

                Console.WriteLine("Status : " + status[i]);
            }



        }
    }
}


