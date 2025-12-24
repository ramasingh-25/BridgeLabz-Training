using System;
using System.Collections.Generic;
using System.Text;

namespace project1.array
{
    class BonusOfEmployee
    {
        static void Main()
        {

            Console.Write("Enter employee salary");
            
            int salary = Convert.ToInt32(Console.ReadLine());   //taking input from user

            Console.Write("Enter years of service");

            int yearsOfService = Convert.ToInt32(Console.ReadLine());


             double bonus = 0;
            if (yearsOfService > 5)

            {
                bonus = salary * 0.05;

            }
            Console.WriteLine("The bonus amount is :" + bonus);
        }
    }
}
