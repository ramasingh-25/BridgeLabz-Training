using System;
using System.Collections.Generic;
using System.Text;

namespace Oops.Scenario_Based.ComputingEmployeeWage
{
    public class EmployeeWageUtility : IEmployeeWages
    {
        protected Random random = new Random();

        public void CheckAttendance()
        {
            int attendance = random.Next(0, 2);

            if (attendance == 1)
                Console.WriteLine("Employee is Present");
            else
                Console.WriteLine("Employee is Absent");
        }
    }
}
