//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Inheritance
//{
//    internal class EmployeeManagementSystem
//    {
        
        
//        class TeamLead : Staff
//        {
//            public int memberCount;

//            public TeamLead(string empName, int empCode, double empPay, int memberCount)
//                : base(empName, empCode, empPay)
//            {
//                this.memberCount = memberCount;
//            }

//            public override void DisplayInfo()
//            {
//                base.DisplayInfo();
//                Console.WriteLine("Total Team Members : " + memberCount);
//            }
//        }

//        class SoftwareEngineer : Staff
//        {
//            public string techStack;

//            public SoftwareEngineer(string empName, int empCode, double empPay, string techStack)
//                : base(empName, empCode, empPay)
//            {
//                this.techStack = techStack;
//            }

//            public override void DisplayInfo()
//            {
//                base.DisplayInfo();
//                Console.WriteLine("Technology Used : " + techStack);
//            }
//        }

//        class Trainee : Staff
//        {
//            public string trainingPeriod;

//            public Trainee(string empName, int empCode, double empPay, string trainingPeriod)
//                : base(empName, empCode, empPay)
//            {
//                this.trainingPeriod = trainingPeriod;
//            }

//            public override void DisplayInfo()
//            {
//                base.DisplayInfo();
//                Console.WriteLine("Training Period : " + trainingPeriod);
//            }
//        }

//        class CompanySystem
//        {
//            static void Main(string[] args)
//            {
//                Console.WriteLine("Enter Team Lead details (Name, Code, Salary, Team Count)");
//                string leadName = Console.ReadLine();

//                int leadCode = int.Parse(Console.ReadLine());
//                double leadSalary = double.Parse(Console.ReadLine());

//                int teamCount = int.Parse(Console.ReadLine());

//                TeamLead lead = new TeamLead(leadName, leadCode, leadSalary, teamCount);

//                Console.WriteLine("\nEnter Software Engineer details (Name, Code, Salary, Technology)");
//                string engName = Console.ReadLine();
//                int engCode = int.Parse(Console.ReadLine());
//                double engSalary = double.Parse(Console.ReadLine());
//                string technology = Console.ReadLine();

//                SoftwareEngineer engineer = new SoftwareEngineer(engName, engCode, engSalary, technology);

//                Console.WriteLine("\nEnter Trainee details (Name, Code, Salary, Duration)");
//                string traineeName = Console.ReadLine();
//                int traineeCode = int.Parse(Console.ReadLine());
//                double traineeSalary = double.Parse(Console.ReadLine());
//                string period = Console.ReadLine();

//                Trainee trainee = new Trainee(traineeName, traineeCode, traineeSalary, period);

//                Console.WriteLine("\n=== TEAM LEAD INFO ===");
//                lead.DisplayInfo();

//                Console.WriteLine("\n=== ENGINEER INFO ===");
//                engineer.DisplayInfo();

//                Console.WriteLine("\n=== TRAINEE INFO ===");
//                trainee.DisplayInfo();
//            }
//        }
//        class Staff
//        {
//            public string empName;
//            public int empCode;
//            public double empPay;

//            public Staff(string empName, int empCode, double empPay)
//            {
//                this.empName = empName;
//                this.empCode = empCode;
//                this.empPay = empPay;
//            }

//            public virtual void DisplayInfo()
//            {
//                Console.WriteLine("Employee Name : " + empName);
//                Console.WriteLine("Employee Code : " + empCode);
//                Console.WriteLine("Monthly Pay   : " + empPay);
//            }
//        }

//    }
//}