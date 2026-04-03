//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    internal class Composition
//    {
//        public static void Main(String[] args)
//        {

//            Company com = new Company("BridgeLabz");


//            Department dbaDept = new Department("DBA");
//            Department marketingDept = new Department("Marketing");


//            dbaDept.AddEmployee("Chitra");
//            dbaDept.AddEmployee("Aman");

//            marketingDept.AddEmployee("Swati");
//            marketingDept.AddEmployee("Khushi");


//            com.AddDepartment(dbaDept);
//            com.AddDepartment(marketingDept);


//            com.ShowCompanyDetails();


//        }
//        class Employee
//    {
//        public string EmployeeName;

//        public Employee(string entername)
//        {
//            this.EmployeeName = entername;
//        }
//    }

//    //another class named as department
//    class Department
//    {
//        public string DepartmentName;
//        public List<Employee> Employees;

//        //parameterized constructor
//        public Department(string enterdepartmentName)
//        {
//            this.DepartmentName = enterdepartmentName;
//            this.Employees = new List<Employee>();
//        }

//        public void AddEmployee(string employeeName)
//        {
//            Employees.Add(new Employee(employeeName));
//        }

//    }

//    //another class named as company
//    class Company
//    {
//        public string CompanyName;
//        public List<Department> Department;

//        //parameterized constructor
//        public Company(string entercompanyName)
//        {
//            this.CompanyName = entercompanyName;
//            this.Department = new List<Department>();
//        }

//        public void AddDepartment(Department department)
//        {
//            Department.Add(department);
//        }

//        public void ShowCompanyDetails()
//        {
//            Console.WriteLine("Company: " + CompanyName);

//            foreach (Department dept in Department)
//            {
//                Console.WriteLine("Department: " + dept.DepartmentName);

//                foreach (Employee emp in dept.Employees)
//                {
//                    Console.WriteLine("Employee: " + emp.EmployeeName);
//                }
//            }
//        }
//    }

    
        
//    }

//}
