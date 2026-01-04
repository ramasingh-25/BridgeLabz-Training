//using Oops.Inheritance;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Sealed
//{
//    class EmployeeManagementSystem
//    {

//        public static string CompanyName = "BridgeLabz Solutions";
//        private static int totalEmployees = 0;

//        public readonly int Id;
//        public string Name;
//        public string Designation;

//        public EmployeeManagementSystem(string Name, int Id, string Designation)
//        {
//            this.Name = Name;
//            this.Id = Id;
//            this.Designation = Designation;
//            totalEmployees++;
//        }

//        public static void DisplayTotalEmployees()
//        {
//            Console.WriteLine("Total Employees: " + totalEmployees);
//        }

//        public void DisplayEmployeeDetails(object emp)
//        {
//            if (emp is EmployeeManagementSystem)
//            {
//                Console.WriteLine("Company Name : " + CompanyName);
//                Console.WriteLine("Employee Name: " + Name);
//                Console.WriteLine("Employee ID  : " + Id);
//                Console.WriteLine("Designation  : " + Designation);
//            }
//            else
//            {
//                Console.WriteLine("Invalid employee object");
//            }
//        }


//        class Employee
//        {
//            static void Main(string[] args)
//            {
//                EmployeeManagementSystem emp1 = new EmployeeManagementSystem("Rama", 121, "Software Developer");
//                EmployeeManagementSystem emp2 = new EmployeeManagementSystem("chitra", 111, "Data Analyst");

//                emp1.DisplayEmployeeDetails(emp1);
//                Console.WriteLine();

//                emp2.DisplayEmployeeDetails(emp2);
//                Console.WriteLine();

//                EmployeeManagementSystem.DisplayTotalEmployees();
//            }
//        }
//    }


//}