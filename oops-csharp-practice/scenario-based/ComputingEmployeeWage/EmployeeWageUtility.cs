using System;
using System.Collections.Generic;
using System.Text;

namespace Oops.Scenario_Based.ComputingEmployeeWage
{
    public class EmployeeWageUtility : IEmployeeWages
    {
        protected Random random = new Random();
        public const int WagePerHour = 20;
        public const int FullDayHours = 8;
        public const int PartTimeHours = 4;
        public void CheckAttendance()
        {
            int attendance = random.Next(0, 2);

            if (attendance == 1)
                Console.WriteLine("Employee is Present");
            else
                Console.WriteLine("Employee is Absent");

        }
        public void CalculateDailyWage()
        {
            int dailyWage = WagePerHour * FullDayHours;
            Console.WriteLine("Daily Wage: " + dailyWage);
        }
        public void CalculatePartTimeWage()
        {
            int wage = PartTimeHours * WagePerHour;
            Console.WriteLine("Part Time Wage: " + wage);
        }
        public void CalculateWageUsingSwitch()
        {
            int empType = random.Next(0, 3);
            int hours = 0;

            switch (empType)
            {
                case 1:
                    hours = FullDayHours;
                    break;
                case 2:
                    hours = PartTimeHours;
                    break;
                default:
                    hours = 0;
                    break;
            }

            Console.WriteLine("Wage: " + (hours * WagePerHour));
        }
    }
}
