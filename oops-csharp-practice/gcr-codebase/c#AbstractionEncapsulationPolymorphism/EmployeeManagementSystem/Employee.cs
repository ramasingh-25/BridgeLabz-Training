//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.EmployeeManagementSystem
//{
//    public abstract class Employee : IDepartment
//    {

//        private int employeeId;
//        private string name;
//        private double baseSalary;
//        private string departmentName;

//        public int EmployeeId
//        {
//            get { return employeeId; }

//            set { employeeId = value; }

//        }

//        public string Name
//        {
//            get { return name; }

//            set { name = value; }

//        }

//        public double BaseSalary
//        {
//            get { return baseSalary; }

//            set { baseSalary = value; }

//        }

//        public abstract double CalculateSalary();

//        public void showDetails()
//        {
//            Console.WriteLine("Employee ID is : " + EmployeeId);
//            Console.WriteLine("Name is        : " + Name);
//            Console.WriteLine("Department is  : " + departmentName);
//            Console.WriteLine("Salary  is     : " + CalculateSalary());

//        }

//        public void AssignDepartment(string deptName)
//        {
//            departmentName = deptName;
//        }


//        public string showDepartmentDetails()
//        {
//            return departmentName;
//        }





//    }
//}
