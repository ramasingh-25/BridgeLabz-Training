using System;
using System.Collections.Generic;
using System.Text;

namespace Oops.Scenario_Based.ComputingEmployeeWage
{
    public interface IEmployeeWages
    {
        void CheckAttendance();
        void CalculateDailyWage();
        void CalculatePartTimeWage();
        void CalculateWageUsingSwitch();
    }
}
