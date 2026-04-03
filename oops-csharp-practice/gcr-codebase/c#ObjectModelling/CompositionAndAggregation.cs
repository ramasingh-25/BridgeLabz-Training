//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    class CompositionAndAggregation
//    {
         
//            public static void Main(String[] args)   //main method
//            {

//                Faculty fac1 = new Faculty("Chitra Singh");
//                Faculty fac2 = new Faculty("Aman Singh");


//                University univ = new University("GLA University");


//                univ.AddDepartment("Computer Science");
//                univ.AddDepartment("Mechanical Engineering");


//                univ.AddFaculty(fac1);
//                univ.AddFaculty(fac2);


//                univ.ShowUniversityDetails();

//                Console.WriteLine("University is deleted");


//                univ = null;


//                fac1.ShowFaculty();
//                fac2.ShowFaculty();
//            }
//        }
        
//        class Faculty
//        {
//            public string Name { get; set; }

//            //constructor
//            public Faculty(string entername)
//            {
//                this.Name = entername;
//            }

//            public void ShowFaculty()
//            {
//                Console.WriteLine("Faculty Name: " + Name);
//            }
//        }

//        //another class named as department
//        class Department
//        {
//            public string DepartmentName { get; set; }

            
//            public Department(string enterdepartmentName)  //constructor
//        {
//                this.DepartmentName = enterdepartmentName;
//            }

//            public void DisplayDepartment()
//            {
//                Console.WriteLine("Department name : " + DepartmentName);
//            }
//        }

      
//        class University
//        {
//            public string UniversityName { get; set; }

//            private List<Department> departments = new List<Department>();
//            private List<Faculty> facultyMembers = new List<Faculty>();

           
//            public University(string enteruniversityName)
//            {
//                this.UniversityName = enteruniversityName;
//            }


//            public void AddDepartment(string departmentName)
//            {
//                departments.Add(new Department(departmentName));
//            }


//            public void AddFaculty(Faculty faculty)
//            {
//                facultyMembers.Add(faculty);
//            }

//            public void ShowUniversityDetails()
//            {
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine(UniversityName);
//                Console.ResetColor();

//                Console.WriteLine("Departments: ");
//                foreach (Department D in departments)
//                {
//                    D.DisplayDepartment();
//                }

//                Console.WriteLine("Faculty Members: ");
//                foreach (Faculty F in facultyMembers)
//                {
//                    F.ShowFaculty();
//                }
//            }
//        }

        
//    }

