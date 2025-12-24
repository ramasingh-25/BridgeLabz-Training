//using System;
//using System.Collections.Generic;
//using System.Text;
//namespace Project1.array
//{
//    public class BonusProgram
//    {
//        public static void Main(string[] args)
//        {
//            int emp_count = 10;

//            double[] salary = new double[emp_count];

//            double[] yearsOfService = new double[emp_count];

//            double[] bonus = new double[emp_count];

//            double[] newSalary = new double[emp_count];


//            double totalBonus = 0;
//            double totalOldSalary = 0;
//            double totalNewSalary = 0;

//            for (int i = 0; i < emp_count; i++)
//            {
//                Console.WriteLine($"\nEnter details for Employee {i + 1}");

//                Console.WriteLine("Enter Salary");
//                salary[i] = double.Parse(Console.ReadLine());

//                Console.WriteLine("Enter Year Of Service");
//                yearsOfService[i] = double.Parse(Console.ReadLine());


//            }

//            for (int i = 0; i < emp_count; i++)
//            {
//                if (yearsOfService[i] > 5)
//                {
//                    bonus[i] = salary[i] * 0.05;
//                }
//                else
//                {
//                    bonus[i] = salary[i] * 0.02;
//                }

//                newSalary[i] = salary[i] + bonus[i];

//                totalOldSalary = totalOldSalary + salary[i];

//                totalBonus = totalBonus + bonus[i];

//                totalNewSalary = totalNewSalary + newSalary[i];
//            }



//            Console.WriteLine("Total Old Salary   : " + totalOldSalary);

//            Console.WriteLine("Total Bonus Amount : " + totalBonus);

//            Console.WriteLine("Total New Salary   : " + totalNewSalary);

//        }
//    }
//}
