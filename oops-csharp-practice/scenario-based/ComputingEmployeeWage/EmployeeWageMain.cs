using System;
using System.Collections.Generic;
using System.Text;

namespace Oops.Scenario_Based.ComputingEmployeeWage
{
    public class EmployeeWageMain
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Welcome to Employee Wage Computation Program");

            IEmployeeWages emp = new EmployeeWageUtility();
            emp.CheckAttendance();
        }

    }
}
