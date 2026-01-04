//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.AccessModifier
//{
// class EmployeeRecord
//    {
//        //main method
//        static void Main(string[] args)
//        {
//            Manager manager = new Manager(202, "CSE", 50000);

//            manager.DisplayDetails();

//            Console.WriteLine("Salary : " + manager.ShowSalary());

//            manager.UpdateSalary(90000);
//            Console.WriteLine("Updated Salary : " + manager.ShowSalary());
//        }
//    }


//    public class Employee
//    {
//        public int employeeID;
//        protected string department;
//        private double salary;

//        public Employee(int employeeID, string department, double salary)
//        {
//            this.employeeID = employeeID;
//            this.department = department;
//            this.salary = salary;
//        }

//        public double ShowSalary()
//        {
//            return salary;
//        }

//        public void UpdateSalary(double newSalary)
//        {
//            if (newSalary > 0)
//            {
//                salary = newSalary;
//            }
//            else
//            {
//                Console.WriteLine("Invalid amount of salary");
//            }
//        }
//    }

//    public class Manager : Employee
//    {
//        public Manager(int employeeID, string department, double salary)
//            : base(employeeID, department, salary)
//        {
//        }

//        public void DisplayDetails()
//        {
//            Console.WriteLine("Manager Details");
//            Console.WriteLine("Employee ID : " + employeeID);
//            Console.WriteLine("Department  : " + department);
//        }
//    }
//}
